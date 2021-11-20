using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class CourseDetail : IEntity
    {
        //TODO: Mostrar los datos del alumno en la lista de calificaciones
        public int Id { get; set; }

        [MaxLength(10)]
        public double FinalScore { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public ICollection<Unit> Units { get; set; }
        public IEnumerable<GradeGrid> GradeGrids { get; set; }
    }
}
