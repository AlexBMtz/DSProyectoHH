using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class CourseType:IEntity
    {
        [MaxLength(2)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Descripción requerida")]
        [StringLength(200)]
        //[RegularExpression("Preteen|Adults|TOEFL", ErrorMessage ="Curso no valido")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Campo requerida")]
        [StringLength(15)]
        public string Schedule { get; set; }

        [Required(ErrorMessage = "Campo requerida")]
        [StringLength(15)]
        public string Frequency { get; set; }

        public Teacher teacher { get; set; }
        public ICollection<Course> courses { get; set; }
    }
}
