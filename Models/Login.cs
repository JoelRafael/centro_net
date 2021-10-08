using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

namespace CentroNet.Models
{
    public class Login
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string Users { get; set; }
        [Required(ErrorMessage = "El password es obligatorio")]
        public string Passwords { get; set; }



    }
}