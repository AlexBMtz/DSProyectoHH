using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Course
    {
        private int id_course;
        private string description;
        private string start_date;

        public int Id_Course { get { return id_course; } set { id_course = value; } }
        public string Description { get { return description; } set { description = value; } }
        public string Start_Date { get { return start_date; } set { start_date = value; } }
    }
}
