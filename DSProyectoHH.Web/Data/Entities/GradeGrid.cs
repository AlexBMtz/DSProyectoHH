using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class GradeGrid:IEntity
    {
        [MaxLength(2)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo requerido")]
        public Project FinalProject { get; set; }

        [MaxLength (10)]
        public double FinalScore { get; set; }

        public Course course { get; set; }
        public Project project { get; set; }

        [Required(ErrorMessage ="Campo requerido")]
        public ICollection<Unit> units { get; set; }

        [Required(ErrorMessage ="Campo requerido")]
        public ICollection<Student> students { get; set; }

        public void Calculate_Final_Score()
        {
            //finalscore = (unit1 * 0.3) + (unit2 * 0.3) + (unit3 * 0.3) + (finalproyect * 0.1);
        }
    }
}
