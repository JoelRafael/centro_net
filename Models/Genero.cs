using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

#nullable disable

namespace CentroNet.Models
{
    public partial class Genero
    {
        public Genero()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        public int Id { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
