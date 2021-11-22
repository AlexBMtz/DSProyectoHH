using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class CourseDetail : IEntity
    { 
        public int Id { get; set; }
        public Student Student { get; set; }

        [MaxLength(10)]
        public double FinalScore { get; set; }

        public ICollection<WrittenQuiz> WrittenQuizzes { get; set; }
        public ICollection<OralQuiz> OralQuizzes { get; set; }
        public ICollection<ClassParticipation> ClassParticipations { get; set; }
        public Project Project { get; set; }
    }
}
