using Microsoft.AspNetCore.Http;

namespace Core.Extensions
{
    public static class PictureHelper
    {
        public static string UploadImage(this IFormFile formFile, string webRootPath)
        {
            var path = "/Images/" + Guid.NewGuid().ToString() + formFile.FileName;
            using (FileStream fileStream = new FileStream(webRootPath + path, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }
            return path;
        }
    }
}
