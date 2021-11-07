using DSProyectoHH.Web.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace DSProyectoHH.Web.Models
{
    public class CoordinatorViewModel : Coordinator
    {
        [DisplayName("Foto del Coordinador")]
        public IFormFile ImageFile { get; set; }
    }
}
