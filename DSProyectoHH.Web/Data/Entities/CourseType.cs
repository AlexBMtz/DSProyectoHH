using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class CourseType : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre del tipo de curso requerido")]
        [StringLength(200)]
        public string CourseTypeName { get; set; }

        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Frequency> Frequencies { get; set; }

    }
}
