using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Data.Entities
{
    public class CourseDetail:IEntity
    {
        public int Id { get; set; }
        public Project FinalProject { get; set; }
        public double FinalScore { get; set; }

        public Course course { get; set; }
        public Project project { get; set; }
        public ICollection<Unit> units { get; set; }
        public ICollection<Student> students { get; set; }

        public void Calculate_Final_Score()
        {
            //finalscore = (unit1 * 0.3) + (unit2 * 0.3) + (unit3 * 0.3) + (finalproyect * 0.1);
        }
    }
}
