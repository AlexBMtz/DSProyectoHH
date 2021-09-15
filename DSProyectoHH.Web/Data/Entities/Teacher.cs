using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Teacher : IEntity
    {

        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }
        public string RFC { get; set; }

        public ICollection<CourseType> courseTypes { get; set; }

    }
}
