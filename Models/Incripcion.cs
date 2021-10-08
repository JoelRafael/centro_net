using System;
using System.Collections.Generic;

#nullable disable

namespace CentroNet.Models
{
    public partial class Incripcion
    {
        public int Id { get; set; }
        public int? CodeMatricula { get; set; }
        public int? Idperiodo { get; set; }
        public int? CodeLevel { get; set; }

        public virtual Matricula CodeMatriculaNavigation { get; set; }
    }
}
