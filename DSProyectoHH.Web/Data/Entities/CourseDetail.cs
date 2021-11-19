using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DSProyectoHH.Web.Data.Entities
{
    public class CourseDetail : IEntity
    {
        public int Id { get; set; }

        public int StudentId { get { return GradeGrids == null ? 0 : GradeGrids.FirstOrDefault(s => s.StudentId == StudentId).StudentId; } }

        public string StudentName { get { return GradeGrids == null ? "" : GradeGrids.FirstOrDefault(s => s.StudentId == StudentId).StudentName; } }
        [MaxLength(10)]
        public double FinalScore { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public ICollection<Unit> Units { get; set; }
        public IEnumerable<GradeGrid> GradeGrids { get; set; }
    }
}
