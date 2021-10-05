using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Data.Entities
{
    public class CourseDetail:IEntity
    {
        public int Id { get; set; }

        public ICollection<Student> Students { get; set; }
        public GradeGrid GradeGrid { get; set; }
    }
}
