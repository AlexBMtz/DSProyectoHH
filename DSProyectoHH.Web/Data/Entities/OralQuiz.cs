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
        [Display(Name = "Comunicación")]
        [Range(1, 5, ErrorMessage = "El valor ingresado debe estar entre 1 y 5")]
        public int Communication { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Gramática")]
        [Range(1, 5, ErrorMessage = "El valor ingresado debe estar entre 1 y 5")]
        public int Grammar { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Vocabulario")]
        [Range(1, 5, ErrorMessage = "El valor ingresado debe estar entre 1 y 5")]
        public int Vocabulary { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Conversaciones")]
        [Range(1, 5, ErrorMessage = "El valor ingresado debe estar entre 1 y 5")]
        public int Conversations { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Fluidez")]
        [Range(1, 5, ErrorMessage = "El valor ingresado debe estar entre 1 y 5")]
        public int Fluency { get; set; }
    }
}
