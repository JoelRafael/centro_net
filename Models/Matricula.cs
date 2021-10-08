using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;
#nullable disable

namespace CentroNet.Models
{
    public partial class Matricula
    {
        public Matricula()
        {
            Incripcions = new HashSet<Incripcion>();
        }

        public int? Idstuden { get; set; }
        public int Code { get; set; }
        public DateTime? CreateAt { get; set; }
        public bool? Status { get; set; }

        public virtual Estudiante IdstudenNavigation { get; set; }
        public virtual ICollection<Incripcion> Incripcions { get; set; }
    }
}
