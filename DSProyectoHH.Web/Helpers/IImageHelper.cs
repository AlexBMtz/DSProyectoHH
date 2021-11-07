using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Helpers
{
    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile imageFile, string nameFile, string folder);
    }
}
