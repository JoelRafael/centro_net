using System;
using System.Collections.Generic;

#nullable disable

namespace CentroNet.Models
{
    public partial class DatosPadre
    {
        public DatosPadre()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        public int Id { get; set; }
        public string NameMother { get; set; }
        public string LastnameMother { get; set; }
        public int? PhoneMother { get; set; }
        public string IdMother { get; set; }
        public DateTime? BirstMother { get; set; }
        public string CityMother { get; set; }
        public string ContryMother { get; set; }
        public string OcupationMother { get; set; }
        public string ConditionMother { get; set; }
        public string DescribesConditionMother { get; set; }
        public string NameFather { get; set; }
        public string LastnameFather { get; set; }
        public string PhoneFather { get; set; }
        public string IdFather { get; set; }
        public DateTime? BirstFather { get; set; }
        public string CityFather { get; set; }
        public string ContryFather { get; set; }
        public string OcupationFather { get; set; }
        public string ConditionFather { get; set; }
        public string DescribesConditionFather { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
