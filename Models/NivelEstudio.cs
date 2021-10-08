using System;
using System.Collections.Generic;

#nullable disable

namespace CentroNet.Models
{
    public partial class NivelEstudio
    {
        public NivelEstudio()
        {
            Materia = new HashSet<Materia>();
        }

        public int Code { get; set; }
        public string NameLevel { get; set; }
        public int? UserCreate { get; set; }
        public DateTime? CreateAt { get; set; }
        public int? UserUpdate { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Materia> Materia { get; set; }
    }
}
