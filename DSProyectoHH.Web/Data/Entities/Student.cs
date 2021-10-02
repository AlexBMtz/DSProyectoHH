using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Student : IEntity
    {
        [MaxLength(2)]
        public int Id { get; set; }

        [Required(ErrorMessage ="La Id del alumno es requerida")]
        [MaxLength(7)]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "El nombre(s) es requerido")]
        [StringLength(30)]
        [Display(Name ="Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Los apellidos son requeridos")]
        [StringLength(40)]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }
        
        [MaxLength((10),ErrorMessage ="Numero invalido")]
        [Display(Name = "Número de celular")]
        public int PhoneNumber { get; set; }

        [Display(Name ="Correo")]
        [StringLength(50)]
        //[RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Formato de corre invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La dirección es requerida")]
        [Display(Name="Dirección")]
        [StringLength(150)]
        public string Address { get; set; }

        [Required(ErrorMessage = "La Fecha de admisión es requerida")]
        [Display(Name = "Fecha de admisión")]
        [StringLength(10)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime AdmissionDate { get; set; }

        public CourseDetail courseDetail { get; set; }

    }
}
