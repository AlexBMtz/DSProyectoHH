﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DSProyectoHH.Web.Data.Entities
{
    public class CourseType : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre del tipo de curso requerido")]
        [StringLength(200)]
        [Display(Name = "Tipo de curso")]
        public string CourseTypeName { get; set; }

        public ICollection<Course> Courses { get; set; }


    }
}
