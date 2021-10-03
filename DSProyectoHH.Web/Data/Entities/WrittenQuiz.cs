using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class WrittenQuiz : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(2)]
        public int SectionA { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(2)]
        public int SectionB { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(2)]
        public int SectionC { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(2)]
        public int SectionD { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(2)]
        public int SectionE { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(2)]
        public int SectionF { get; set; }

    }
}
