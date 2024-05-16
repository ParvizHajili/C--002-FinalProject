using Microsoft.AspNetCore.Http;

namespace Core.Extenstion
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
