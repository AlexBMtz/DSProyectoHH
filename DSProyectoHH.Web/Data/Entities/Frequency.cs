using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Frequency : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre de la frecuencia requerido")]
        [StringLength(200)]
        [Display(Name = "Frecuencia")]
        public string Name { get; set; }

        public ICollection<CourseType> CourseTypes { get; set; }
    }
}
