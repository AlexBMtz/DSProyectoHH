using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class WrittenQuiz : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Sección A")]
        [Range(1, 10, ErrorMessage = "El valor ingresado debe estar entre 1 y 10")]
        public int SectionA { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Sección B")]
        [Range(1, 10, ErrorMessage = "El valor ingresado debe estar entre 1 y 10")]
        public int SectionB { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Sección C")]
        [Range(1, 10, ErrorMessage = "El valor ingresado debe estar entre 1 y 10")]
        public int SectionC { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Sección D")]
        [Range(1, 10, ErrorMessage = "El valor ingresado debe estar entre 1 y 10")]
        public int SectionD { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Sección E")]
        [Range(1, 10, ErrorMessage = "El valor ingresado debe estar entre 1 y 10")]
        public int SectionE { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Sección F")]
        [Range(1, 10, ErrorMessage = "El valor ingresado debe estar entre 1 y 10")]
        public int SectionF { get; set; }

    }
}
