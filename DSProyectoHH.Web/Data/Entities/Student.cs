using System;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Student : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Id del alumno es requerido")]
        [Display(Name = "Id del Alumno")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "La Fecha de admisión es requerida")]
        [Display(Name = "Fecha de admisión")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AdmissionDate { get; set; }

        [Display(Name = "Foto del Estudiante")]
        public string ImageUrl { get; set; }

        public User User { get; set; }

    }
}
