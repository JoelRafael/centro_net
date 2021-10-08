using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace CentroNet.Models
{
    public class Changepassword
    {
        [Required(ErrorMessage = "El campo Id es obligatorio")]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Password es requerido")]
        [MinLength(8, ErrorMessage = "El password debe tener un minimo de 8 caracteres ")]
        [MaxLength(16, ErrorMessage = "El password debe tener un maximo de 16 caracteres ")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "El password no coinciden")]
        public string ConfirPasswords { get; set; }

    }
}