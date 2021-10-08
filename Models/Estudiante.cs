using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

#nullable disable

namespace CentroNet.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            FichaMedicaEstudiantes = new HashSet<FichaMedicaEstudiante>();
            Matriculas = new HashSet<Matricula>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Iduser es requerido")]
        public int Iduser { get; set; }
        [Required(ErrorMessage = "El campo Names  es requerido")]
        public string Names { get; set; }
        [Required(ErrorMessage = "El campo Lastname es requerido")]
        public string Lastnames { get; set; }
        [Required(ErrorMessage = "El campo Birthdate es requerido")]
        public DateTime Birthdate { get; set; }

        public bool Status { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? IdDatospadre { get; set; }
        public int? Idtutor { get; set; }
        public int? Idgenero { get; set; }
        public string number_certificate { get; set; }



        public virtual DatosPadre IdDatospadreNavigation { get; set; }
        public virtual Genero IdgeneroNavigation { get; set; }
        public virtual DatosTutor IdtutorNavigation { get; set; }
        public virtual Usuario IduserNavigation { get; set; }
        public virtual ICollection<FichaMedicaEstudiante> FichaMedicaEstudiantes { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
