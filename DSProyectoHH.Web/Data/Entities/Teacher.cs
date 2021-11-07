using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Teacher : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La ID es requerida")]
        [DisplayName("Clave del maestro")]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "La Fecha de contratación es requerida")]
        [DisplayName("Fecha de contratación")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime HiringDate { get; set; }

        [Required(ErrorMessage = "RFC requerida")]
        [DisplayName("RFC")]
        [MaxLength(13, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string RFC { get; set; }

        [DisplayName("Foto del Profesor")]
        public string ImageUrl { get; set; }

        public ICollection<Course> Courses { get; set; }

        public User User { get; set; }
    }
}
