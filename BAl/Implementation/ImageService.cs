using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interface;
using DAO.Interface;
using Entity.Common;
using Entity.Model;
using Helper;
using Microsoft.AspNetCore.Http;

namespace BAL.Implementation
{
     public class ImageService : IImageService
    {
        IImageRepo _repo;
        public ImageService(IImageRepo repo)
        {
            _repo = repo;
        }



        public ResponseData<Image> DeleteImage(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseData<List<Image>> GetAllImages()
        {
            throw new NotImplementedException();
        }

        public ResponseData<Image> GetImageById(int id)
        {
            throw new NotImplementedException();
        }



        public ResponseData<Image> SaveImage(IFormFile file, string rootPath)
        {
            try
            {
                var fileName = FileHelper.UploadImage(file, rootPath);
                _repo.SaveImage(new Image
                {
                    FileName = fileName,
                    FilePath = Path.Combine(rootPath, "uploads", fileName),
                    UploadedOn = DateTime.Now
                });

                return new ResponseData<Image>
                {
                    Success = true,
                    Message = "Image saved successfully.",
                    Data = new Image
                    {
                        FileName = fileName,
                        FilePath = Path.Combine(rootPath, "uploads", fileName),
                        UploadedOn = DateTime.Now
                    }
                };
            }
            catch (Exception ex)
            {
                return new ResponseData<Image>
                {
                    Success = false,
                    Message = $"An error occurred while saving the image: {ex.Message}"
                };
            }
        }


        public ResponseData<Image> UpdateImage(IFormFile file, int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
