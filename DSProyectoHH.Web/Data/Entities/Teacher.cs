using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Teacher : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="La ID es requerida")]
        [DisplayName("Clave del maestro")]
        public int TeacherId { get; set; }

        [Required(ErrorMessage ="RFC requerida")]
        [DisplayName("RFC")]
        [StringLength(13)]
        public string RFC { get; set; }

        public ICollection<CourseType> CourseTypes { get; set; }
        public User User { get; set; }

    }
}
