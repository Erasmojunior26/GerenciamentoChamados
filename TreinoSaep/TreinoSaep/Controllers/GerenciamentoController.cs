using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TreinoSaep.Models;

namespace TreinoSaep.Controllers
{
    public class GerenciamentoController : Controller
    {
        private readonly db_ChamadoContext _context;

        public GerenciamentoController(db_ChamadoContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            var chamados = await _context.Chamados.Include(t => t.Usuario).ToListAsync();

            var viewModel = new Gerenciamento
            {
                Aberto = chamados.Where(t => t.Statuss == "Aberto").ToList(),
                Em_andamento = chamados.Where(t => t.Statuss == "Em andamento").ToList(),
                Finalizado = chamados.Where(t => t.Statuss == "Finalizado").ToList(),
            };

            return View(viewModel);
        }
    }
}
