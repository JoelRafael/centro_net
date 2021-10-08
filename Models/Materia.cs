using System;
using System.Collections.Generic;

#nullable disable

namespace CentroNet.Models
{
    public partial class Materia
    {
        public int Code { get; set; }
        public int? CodeLevel { get; set; }
        public string NameCourse { get; set; }
        public string Description { get; set; }
        public int? UserCreate { get; set; }
        public DateTime? CreateAt { get; set; }
        public int? UserUpdate { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual NivelEstudio CodeLevelNavigation { get; set; }
    }
}
