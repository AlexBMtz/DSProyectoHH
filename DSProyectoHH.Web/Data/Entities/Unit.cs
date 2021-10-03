using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Unit:IEntity
    {
        [MaxLength(2)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public WrittenQuiz WrittenQuiz { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public OralQuiz OralQuiz { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public ClassParticipation ClassParticipation { get; set; }

        public OralQuiz oralQuiz { get; set; }
        public WrittenQuiz writtenQuiz { get; set; }
        public ClassParticipation classParticipation { get; set; }
        public GradeGrid courseDetail { get; set; }
    }
}
