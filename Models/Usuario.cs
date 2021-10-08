using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace CentroNet.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Users es requerido")]
        public string Users { get; set; }
        [Required(ErrorMessage = "El campo Password es requerido")]
        [MinLength(8, ErrorMessage = "El password debe tener un minimo de 8 caracteres ")]
        [MaxLength(16, ErrorMessage = "El password debe tener un maximo de 16 caracteres ")]
        public string Passwords { get; set; }
        [Compare("Passwords", ErrorMessage = "El password no coinciden")]
        [NotMapped]
        public string? ConfirPasswords { get; set; }
        public int? IdRol { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? Status { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
