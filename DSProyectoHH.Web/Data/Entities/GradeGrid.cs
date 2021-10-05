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

        [Required(ErrorMessage ="Campo requerido")]
        public ICollection<Unit> Units { get; set; }
    }
}
