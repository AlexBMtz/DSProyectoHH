using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Project:IEntity
    {
        [MaxLength(2)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(1)]
        public int Research { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(1)]
        public int ProductQuality { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(1)]
        public int CollabWork { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(1)]
        public int Creativity { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(1)]
        public int Fluency { get; set; }

        public GradeGrid courseDetail { get; set; }

    }
}
