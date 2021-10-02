using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;


namespace DSProyectoHH.Web.Data.Entities
{
    public class ClassParticipation : IEntity
    {

        [MaxLength(2)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo Requerido")]
        [MaxLength(2)]
        public int Listening { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [MaxLength(2)]
        public int Reading { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [MaxLength(2)]
        public int SpokenInteraction { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [MaxLength(2)]
        public int SpokenProduction { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [MaxLength(2)]
        public int Fluency { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public Unit unit { get; set; }
    }
}
