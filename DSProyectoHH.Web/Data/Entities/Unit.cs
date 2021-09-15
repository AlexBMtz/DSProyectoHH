using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Unit:IEntity
    {
        public int Id { get; set; }
        public WrittenQuiz WrittenQuiz { get; set; }
        public OralQuiz OralQuiz { get; set; }
        public ClassParticipation ClassParticipation { get; set; }

        public OralQuiz oralQuiz { get; set; }
        public WrittenQuiz writtenQuiz { get; set; }
        public ClassParticipation classParticipation { get; set; }
        public CourseDetail courseDetail { get; set; }
    }
}
