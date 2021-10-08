using System;
using System.Collections.Generic;

#nullable disable

namespace CentroNet.Models
{
    public partial class FichaMedicaEstudiante
    {
        public int? Idstuden { get; set; }
        public int Id { get; set; }
        public string TypeFeeding { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string HealthSystem { get; set; }
        public string Allergy { get; set; }
        public string TreatmentAllergy { get; set; }
        public string GroupBlood { get; set; }
        public string Disease { get; set; }
        public string SurgicalIntervention { get; set; }
        public string MedicalTreatment { get; set; }
        public string Observartion { get; set; }

        public virtual Estudiante IdstudenNavigation { get; set; }
    }
}
