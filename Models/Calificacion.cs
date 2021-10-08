using System;
using System.Collections.Generic;

#nullable disable

namespace CentroNet.Models
{
    public partial class Calificacion
    {
        public int? Idiscription { get; set; }
        public string Course { get; set; }
        public string Month { get; set; }
        public int? Quantification { get; set; }

        public virtual Incripcion IdiscriptionNavigation { get; set; }
    }
}
