using System;
using System.Collections.Generic;

#nullable disable

namespace CentroNet.Models
{
    public partial class DatosTutor
    {
        public DatosTutor()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneCel { get; set; }
        public string Phone { get; set; }
        public string IdTutor { get; set; }
        public DateTime? Birt { get; set; }
        public string City { get; set; }
        public string Contry { get; set; }
        public string AddressLives { get; set; }
        public string Sector { get; set; }
        public string NumberHouse { get; set; }
        public string Condition { get; set; }
        public string DescribeCondition { get; set; }
        public string Ocupation { get; set; }
        public int? NumberChildren { get; set; }
        public string LevelStudent { get; set; }

        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
