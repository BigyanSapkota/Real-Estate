using BAL.Interface;
using Entity.Common;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace RealEstate.Controllers
{
    public class ImageController : Controller
    {
        IImageService _service;
        private readonly IWebHostEnvironment _env;
        public ImageController(IImageService service, IWebHostEnvironment env)
        {
            _env = env;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = "No file uploaded."
                });
            }

            var result = _service.SaveImage(file, _env.WebRootPath);
            if (result == null)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = "Failed"
                });
            }
            else
            {

                var Gid = result.Data.FileName;
                var fileUrl = result.Data.FilePath;

                return Ok(new
                {
                    Success = true,
                    FileId = Gid,
                    FileUrl = fileUrl
                });
            }
        }




    }
}

