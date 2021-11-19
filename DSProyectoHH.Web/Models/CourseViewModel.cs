using DSProyectoHH.Web.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Models
{
    public class CourseViewModel : Course
    {
        [Display(Name = "Frecuencia")]
        public int FrequencyId { get; set; }
        public IEnumerable<SelectListItem> Frequencies { get; set; }

        [Display(Name = "Horario")]
        public int ScheduleId { get; set; }
        public IEnumerable<SelectListItem> Schedules { get; set; }

        [Display(Name = "Tipo de Curso")]
        public int CourseTypeId { get; set; }
        public IEnumerable<SelectListItem> CourseTypes { get; set; }

        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }
        public IEnumerable<SelectListItem> Teachers { get; set; }


    }
}
