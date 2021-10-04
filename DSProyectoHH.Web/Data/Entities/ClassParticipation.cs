using System;
using System.ComponentModel.DataAnnotations;


namespace DSProyectoHH.Web.Data.Entities
{
    public class ClassParticipation : IEntity
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Escucha")]
        [Range(0, 2, ErrorMessage = "El valor ingresado debe estar entre 0 y 2")]
        public int Listening { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Lectura")]
        [Range(0, 2, ErrorMessage = "El valor ingresado debe estar entre 0 y 2")]
        public int Reading { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Interacción oral")]
        [Range(0, 2, ErrorMessage = "El valor ingresado debe estar entre 0 y 2")]
        public int SpokenInteraction { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Producción del habla")]
        [Range(0, 2, ErrorMessage = "El valor ingresado debe estar entre 0 y 2")]
        public int SpokenProduction { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Fluidez")]
        [Range(0, 2, ErrorMessage = "El valor ingresado debe estar entre 0 y 2")]
        public int Fluency { get; set; }
    }
}
