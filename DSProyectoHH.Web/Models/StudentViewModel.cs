namespace DSProyectoHH.Web.Models
{
    using DSProyectoHH.Web.Data.Entities;
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel;

    public class StudentViewModel : Student
    {
        [DisplayName("Foto del Estudiante")]
        public IFormFile ImageFile { get; set; }
    }
}
