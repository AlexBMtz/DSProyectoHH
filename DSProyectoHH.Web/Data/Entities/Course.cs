using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Course:IEntity
    {
        [MaxLength(2)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Id requerida")]
        [MaxLength(2)]
        public int CourseId { get; set; }

        [Required(ErrorMessage ="Descripción requerida")]
        [StringLength(200)]
        public string Description { get; set; }

        [Required(ErrorMessage = "La Fecha de inicio es requerida")]
        [Display(Name = "Fecha de inicio")]
        [StringLength(10)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string StartingDate { get; set; }

        public CourseDetail courseDetail { get; set; }
        public CourseType courseType { get; set; }
    }
}
