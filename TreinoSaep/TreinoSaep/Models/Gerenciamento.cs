namespace TreinoSaep.Models
{
    public class Gerenciamento
    {
        public List<Chamado> Aberto { get; set; } = new List<Chamado>();
        public List<Chamado> Em_andamento { get; set; } = new List<Chamado>();
        public List<Chamado> Finalizado { get; set; } = new List<Chamado>();

    }
}
