using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Helpers
{
    public class ImageHelper : IImageHelper
    {
        public async Task<string> UploadImageAsync(IFormFile imageFile, string nameFile, string folder)
        {
            if (imageFile == null)
            {
                var file = $"_default.png";
                return $"~/images/{folder}/{file}";
            }
            else
            {
                var guid = Guid.NewGuid().ToString();
                var file = $"{nameFile}-{guid}.png";
                var path = Path.Combine(Directory.GetCurrentDirectory(),
                    $"wwwroot\\images\\{folder}", file);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                return $"~/images/{folder}/{file}";
            }
        }

        public async Task<string> UpdateImageAsync(IFormFile imageFile, string url)
        {
            if (imageFile == null && url.Contains("_default.png"))
            {
                return "~/images/_default.png";
            }
            else
            {
                string urlTemp = url.Substring(1);
                urlTemp = $"wwwroot{urlTemp}";

                if(imageFile != null)
                {
                    using (var stream = new FileStream(urlTemp, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                }
                return url;
            }
        }
    }
}
