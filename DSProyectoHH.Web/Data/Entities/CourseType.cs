using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Data.Entities
{
    public class CourseType:IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Schedule { get; set; }
        public string Frequency { get; set; }

        public Teacher teacher { get; set; }
        public ICollection<Course> courses { get; set; }
    }
}
