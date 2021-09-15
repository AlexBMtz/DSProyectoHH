using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Project:IEntity
    {
        public int Id { get; set; }
        public int Research { get; set; }
        public int ProductQuality { get; set; }
        public int CollabWork { get; set; }
        public int Creativity { get; set; }
        public int Fluency { get; set; }

        public CourseDetail courseDetail { get; set; }

    }
}
