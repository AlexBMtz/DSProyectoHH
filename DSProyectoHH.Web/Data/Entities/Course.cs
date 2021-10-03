using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Course : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Id requerida")]
        [Display(Name = "Id de Curso")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Descripción requerida")]
        [Display(Name = "Nombre del Curso")]
        [StringLength(15)]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es requerida")]
        [Display(Name = "Fecha de inicio")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartingDate { get; set; }
        public GradeGrid GradeGrid { get; set; }
        public ICollection<CourseType> CourseTypes { get; set; }
    }
}
