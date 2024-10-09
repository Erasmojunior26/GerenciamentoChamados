using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TreinoSaep.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Chamados = new HashSet<Chamado>();
        }

        [Key]
        public int Idusu { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "O email é obrigatório")]

        [Remote("ValidarEmailUnico", "Usuarios", ErrorMessage = "E-mail já cadastrado")]
        public string? Email { get; set; }

        public virtual ICollection<Chamado> Chamados { get; set; }
    }
}
