using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Helper
{
     public class FileHelper
    {
        public static string UploadImage(IFormFile file, string uploadRoot)
        {
            var uploads = Path.Combine(uploadRoot, "uploads");
            Directory.CreateDirectory(uploads);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var fullPath = Path.Combine(uploads, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return fileName;
        }

        public static byte[] DownloadImage(string uploadRoot, string fileName)
        {
            var filePath = Path.Combine(uploadRoot, "Images", fileName);
            return File.Exists(filePath) ? File.ReadAllBytes(filePath) : null;
        }

        public static void DeleteImage(string uploadRoot, string fileName)
        {
            var filePath = Path.Combine(uploadRoot, "Images", fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static string EditImage(IFormFile newFile, string uploadRoot, string oldFileName)
        {
            DeleteImage(uploadRoot, oldFileName);
            return UploadImage(newFile, uploadRoot);
        }
    }
}
