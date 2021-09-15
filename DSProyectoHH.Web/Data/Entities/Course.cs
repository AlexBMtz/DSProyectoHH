using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Course:IEntity
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Description { get; set; }
        public string StartingDate { get; set; }

        public CourseDetail courseDetail { get; set; }
        public CourseType courseType { get; set; }
    }
}
