using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Data.Entities
{
    public class CourseDetail:IEntity
    {
        public int Id { get; set; }
        public Unit  Unit1 { get; set; }
        public Unit Unit2 { get; set; }
        public Unit Unit3 { get; set; }
        public Project FinalProject { get; set; }
        public double FinalScore { get; set; }

        public void Calculate_Final_Score()
        {
            //finalscore = (unit1 * 0.3) + (unit2 * 0.3) + (unit3 * 0.3) + (finalproyect * 0.1);
        }
    }
}
