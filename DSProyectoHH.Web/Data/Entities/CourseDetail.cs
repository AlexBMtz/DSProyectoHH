using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class CourseDetail : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public Project FinalProject { get; set; }

        [MaxLength(10)]
        public double FinalScore { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public ICollection<Unit> Units { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
