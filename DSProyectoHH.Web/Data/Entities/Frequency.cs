using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Frequency : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre de la frecuencia requerido")]
        [StringLength(200)]
        public string name { get; set; }

        public CourseType CourseType { get; set; }
    }
}
