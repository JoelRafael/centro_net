using System;
using System.Collections.Generic;

#nullable disable

namespace CentroNet.Models
{
    public partial class Periodo
    {
        public int Id { get; set; }
        public string FromYear { get; set; }
        public string UntilYear { get; set; }
        public bool? Status { get; set; }
    }
}
