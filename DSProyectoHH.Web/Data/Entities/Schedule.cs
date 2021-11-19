using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Schedule : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La hora de inicio es requerida")]
        [Display(Name = "Hora de inicio")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0: hh:mm tt }")]
        public DateTime StartingHour { get; set; }

        [Required(ErrorMessage = "La hora de salida es requerida")]
        [Display(Name = "Hora de salida")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0: hh:mm tt}")]
        public DateTime EndingHour { get; set; }

        public ICollection<Course> Courses { get; set; }


    }
}
