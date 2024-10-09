using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TreinoSaep.Models;

namespace TreinoSaep.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly db_ChamadoContext _context;

        public UsuariosController(db_ChamadoContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
              return _context.Usuarios != null ? 
                          View(await _context.Usuarios.ToListAsync()) :
                          Problem("Entity set 'db_ChamadoContext.Usuarios'  is null.");
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Idusu == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idusu,Nome,Email")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Chamados");
            }
            return View(usuario);
        }

        public ActionResult ValidarEmailUnico(string Email)
        {
            var emailDisponivel = _context.Usuarios.Where(u => u.Email == Email).Count() == 0;
            return Json(emailDisponivel);
        }


        private bool UsuarioExists(int id)
        {
          return (_context.Usuarios?.Any(e => e.Idusu == id)).GetValueOrDefault();
        }
    }
}
