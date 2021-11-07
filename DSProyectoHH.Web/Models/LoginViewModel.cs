using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="Correo Electrónico")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name ="Recuérdame")]
        public bool RememberMe { get; set; }
    }
}
