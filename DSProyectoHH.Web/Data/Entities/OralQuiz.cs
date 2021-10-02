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
        [MaxLength(2)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(2)]
        public int Communication { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(2)]
        public int Grammar { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(2)]
        public int Vocabulary { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(2)]
        public int ConversationS { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(2)]
        public int Fluency { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public Unit unit { get; set; }
    }
}
