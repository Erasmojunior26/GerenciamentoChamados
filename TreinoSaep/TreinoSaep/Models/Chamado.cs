using System;
using System.Collections.Generic;

namespace TreinoSaep.Models
{
    public partial class Chamado
    {
        public int Idchamado { get; set; }
        public string? Descricao { get; set; }
        public string? Setor { get; set; }
        public string? Statuss { get; set; }
        public string? Prioridade { get; set; }
        public int? UsuarioId { get; set; }

        public virtual Usuario? Usuario { get; set; }
    }
}
