using System;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class StudentGrade : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Sección A")]
        [Range(0, 8, ErrorMessage = "Puntuación inválida")]
        public int SectionA { get; set; }

        [Display(Name = "Sección B")]
        [Range(0, 8, ErrorMessage = "Puntuación inválida")]
        public int SectionB { get; set; }

        [Display(Name = "Sección C")]
        [Range(0, 8, ErrorMessage = "Puntuación inválida")]
        public int SectionC { get; set; }

        [Display(Name = "Sección D")]
        //[Range(0, 8, ErrorMessage = "Puntuación inválida")]
        public int SectionD { get; set; }

        [Display(Name = "Sección E")]
        [Range(0, 8, ErrorMessage = "Puntuación inválida")]
        public int SectionE { get; set; }

        [Display(Name = "Sección F")]
        [Range(0, 8, ErrorMessage = "Puntuación inválida")]
        public int SectionF { get; set; }


        [Display(Name = "Comunicación")]
        [Range(1, 5, ErrorMessage = "El valor ingresado debe estar entre 1 y 5")]
        public int Communication { get; set; }

        //[Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Gramática")]
        [Range(1, 5, ErrorMessage = "El valor ingresado debe estar entre 1 y 5")]
        public int Grammar { get; set; }

        //[Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Vocabulario")]
        [Range(1, 5, ErrorMessage = "El valor ingresado debe estar entre 1 y 5")]
        public int Vocabulary { get; set; }

        //[Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Conversaciones")]
        [Range(1, 5, ErrorMessage = "El valor ingresado debe estar entre 1 y 5")]
        public int ConversationStrategies { get; set; }

        //[Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Fluidez")]
        [Range(1, 5, ErrorMessage = "El valor ingresado debe estar entre 1 y 5")]
        public int Fluency { get; set; }

        ////[Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Escucha")]
        [Range(0, 2, ErrorMessage = "El valor ingresado debe estar entre 0 y 2")]
        public double Listening { get; set; }

        ////[Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Lectura")]
        [Range(0, 2, ErrorMessage = "El valor ingresado debe estar entre 0 y 2")]
        public double Reading { get; set; }

        ////[Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Interacción oral")]
        [Range(0, 2, ErrorMessage = "El valor ingresado debe estar entre 0 y 2")]
        public double SpokenInteraction { get; set; }

        ////[Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Producción del habla")]
        [Range(0, 2, ErrorMessage = "El valor ingresado debe estar entre 0 y 2")]
        public double SpokenProduction { get; set; }

        //// [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Fluidez")]
        [Range(0, 2, ErrorMessage = "El valor ingresado debe estar entre 0 y 2")]
        public double ClassFluency { get; set; }

        [Display(Name = "Proyecto Final")]
        [Range(0, 10, ErrorMessage = "El valor ingresado debe estar entre 0 y 10")]
        public double FinalProject { get; set; }
        public double WQGrade { get { return (SectionA + SectionB + SectionC + SectionD + SectionE + SectionF) * .2; } }
        public double OQGrade { get { return ((Communication + Grammar + Vocabulary + Fluency + ConversationStrategies) * 10) / 25; } }
        public double CPQGrage { get { return Listening + Reading + SpokenInteraction + SpokenProduction + ClassFluency; } }

    }
}
