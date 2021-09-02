using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Course_Type
    {
        private int id_course_type;
        private string description;

        public int Id_Course_Type { get { return id_course_type; } set { id_course_type = value; } }
        public string Description { get { return description; } set { description = value; } }
    }
}
