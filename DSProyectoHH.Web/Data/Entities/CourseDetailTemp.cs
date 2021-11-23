using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class CourseDetailTemp : IEntity
    {
        public int Id { get; set; }
        public Student Student { get; set; }
    }
}
