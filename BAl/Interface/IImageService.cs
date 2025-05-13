using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Common;
using Entity.Model;
using Microsoft.AspNetCore.Http;

namespace BAL.Interface
{
     public interface IImageService
    {
       ResponseData<Image> SaveImage(IFormFile file, string rootPath);
       ResponseData<List<Image>> GetAllImages();
        ResponseData<Image> GetImageById(int id);
        ResponseData<Image> UpdateImage(IFormFile file, int id);
         ResponseData<Image> DeleteImage(int id);
    }
}
