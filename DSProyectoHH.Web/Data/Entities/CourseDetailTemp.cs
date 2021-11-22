using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class CourseDetailTemp : IEntity
    {
        public int Id { get; set; }
        public Student Student { get; set; }

        [MaxLength(10)]
        public double FinalScore { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public ICollection<Unit> Units { get; set; }
        public Project Project { get; set; }
    }
}
