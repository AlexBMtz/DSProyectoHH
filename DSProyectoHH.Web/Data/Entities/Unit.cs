using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Unit:IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public WrittenQuiz WrittenQuiz { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public OralQuiz OralQuiz { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public ClassParticipation ClassParticipation { get; set; }
        public GradeGrid GradeGrid { get; set; }
    }
}
