using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Models
{
    public class AddStudentViewModel
    {
        [Display(Name = "Estudiante")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar a un estudiante")]
        public int StudentId { get; set; }
        public IEnumerable<SelectListItem> Students { get; set; }
    }
}
