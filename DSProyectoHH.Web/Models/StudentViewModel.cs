namespace DSProyectoHH.Web.Models
{
    using DSProyectoHH.Web.Data.Entities;
    using Microsoft.AspNetCore.Http;

    public class StudentViewModel : Student
    {
        public IFormFile ImageFile { get; set; }
    }
}
