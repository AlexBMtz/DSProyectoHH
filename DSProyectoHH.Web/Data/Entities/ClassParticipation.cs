using System;
using System.ComponentModel.DataAnnotations;


namespace DSProyectoHH.Web.Data.Entities
{
    public class ClassParticipation : IEntity
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [MaxLength(2)]
        [Range(0, 2)]
        public int Listening { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [MaxLength(2)]
        [Range(0, 2)]
        public int Reading { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [MaxLength(2)]
        [Range(0, 2)]
        public int SpokenInteraction { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [MaxLength(2)]
        [Range(0, 2)]
        public int SpokenProduction { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [MaxLength(2)]
        [Range(0, 2)]
        public int Fluency { get; set; }

        public Unit Unit { get; set; }
    }
}
