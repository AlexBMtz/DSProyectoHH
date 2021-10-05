using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Course : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Id del curso requerida")]
        [Display(Name = "Id del Curso")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Nombre del curso requerido")]
        [Display(Name = "Nombre del Curso")]
        [StringLength(15)]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es requerida")]
        [Display(Name = "Fecha de inicio")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartingDate { get; set; }

        public Teacher Teacher { get; set; }
        public Schedule Schedule { get; set; }
        public Frequency Frequency { get; set; }
        public CourseType CourseType { get; set; }
        public CourseDetail CourseDetail { get; set; }


    }
}
