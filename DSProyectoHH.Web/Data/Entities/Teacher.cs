using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Teacher : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="La ID es requerida")]
        [DisplayName("Clave del maestro")]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "La Fecha de contratación es requerida")]
        [Display(Name = "Fecha de contratación")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime HiringDate { get; set; }

        [Required(ErrorMessage ="RFC requerida")]
        [DisplayName("RFC")]
        [StringLength(13)]
        public string RFC { get; set; }

        public ICollection<Course> Courses { get; set; }
        public User User { get; set; }

    }
}
