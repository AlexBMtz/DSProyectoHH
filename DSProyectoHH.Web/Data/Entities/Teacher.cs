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
        [MaxLength(2)]
        public int Id { get; set; }

        [Required(ErrorMessage ="La ID es requerida")]
        [MaxLength(6)]
        public int TeacherId { get; set; }

        [Required(ErrorMessage =("El nombre es obligatorio"))]
        [StringLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = ("Los apellidos son obligatorio"))]
        [StringLength(40)]
        public string LastName { get; set; }

        [MaxLength(10)]
        public int Telephone { get; set; }

        [Display(Name = "Correo")]
        [StringLength(50)]
        public string Email { get; set; }

        
        [Required(ErrorMessage =("RFC requerida"))]
        [StringLength(13)]
        public string RFC { get; set; }

        public ICollection<CourseType> courseTypes { get; set; }

    }
}
