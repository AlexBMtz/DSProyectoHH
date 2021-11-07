namespace DSProyectoHH.Web.Models
{
    using DSProyectoHH.Web.Data.Entities;
    using Microsoft.AspNetCore.Http;

    public class TeacherViewModel : Teacher
    {
        public IFormFile ImageFile { get; set; }
    }
}
