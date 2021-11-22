using System;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Project : IEntity
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Range(0, 2)]
        public int Research { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Range(0, 2)]
        public int ProductQuality { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Range(0, 2)]
        public int CollabWork { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Range(0, 2)]
        public int Creativity { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Range(0, 2)]
        public int Fluency { get; set; }
    }
}
