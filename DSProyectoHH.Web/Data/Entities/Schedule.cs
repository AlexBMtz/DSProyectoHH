﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class Schedule : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La hora de inicio es requerida")]
        [Display(Name = "Fecha de inicio")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:t}")]
        public DateTime StartingHour { get; set; }

        [Required(ErrorMessage = "La hora de salida es requerida")]
        [Display(Name = "Fecha de salida")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:t}")]
        public DateTime EndingHour { get; set; }

        public CourseType CourseType { get; set; }


    }
}
