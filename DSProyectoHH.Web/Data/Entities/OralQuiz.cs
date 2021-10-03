using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class OralQuiz : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(2)]
        [Range(1,5)]
        public int Communication { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(2)]
        [Range(1, 5)]
        public int Grammar { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(2)]
        [Range(1, 5)]
        public int Vocabulary { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(2)]
        [Range(1, 5)]
        public int ConversationS { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(2)]
        [Range(1, 5)]
        public int Fluency { get; set; }
    }
}
