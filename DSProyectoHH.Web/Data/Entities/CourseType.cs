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
    }
}
