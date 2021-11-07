namespace DSProyectoHH.Web.Models
{
    using DSProyectoHH.Web.Data.Entities;
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel;

    public class TeacherViewModel : Teacher
    {
        [DisplayName("Foto del Profesor")]
        public IFormFile ImageFile { get; set; }
    }
}
