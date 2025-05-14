using BAL.Interface;
using Entity.Common;
using Entity.Model;
using Entity.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace RealEstate.Controllers
{
    public class PropertyController : Controller
    {
        IPropertyService _service;
        public PropertyController(IPropertyService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> allProperty()
        {
            var data = await _service.GetAll(string.Empty, string.Empty, string.Empty);

            if (data == null || data.Data == null)
            {
                return View(new List<Property>());
            }

            return View(data.Data);
        }



        public async Task<IActionResult> PropertyDetails(int id)
        {
            var data = await _service.GetById(id);
            if(data == null)
    {
                return NotFound(); 
            }

            return View(data.Data);
            
        }



        [HttpGet("ByType/{type}")]
        public JsonResult GetByType(string type)
        {
            var data = _service.GetByType(type);
            return Json(data);
        }

   

        [HttpGet]

        public async Task<JsonResult> GetById(int id)
        {
            try
            {
                var result = await _service.GetById(id);
                if (!result.Success)
                {
                    return Json(new { Success = false, Message = result.Message });
                }

                return Json(new { Success = true, Data = result.Data });
            }
            catch (Exception ex)
            {
             
                return Json(new
                {
                    Success = false,
                    Message = "Server error: " + ex.Message
                });
            }
        }




        public async Task<JsonResult> GetAll([FromBody] PropertyVM vm)
        {
  
            var data = await _service.GetAll(vm.PropertyName,vm.PropertyType,vm.PropertyPrice);
            return Json(data);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public JsonResult Save([FromBody] PropertyVM vm)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage)
                            .ToList();

                return Json(new
                {
                    Success = false,
                    Errors = errors
                });
            }

            var data = _service.Save(vm);
            return Json(new
            {
                Success = true,
                Data = data
            });
        }

        [HttpDelete("{id:int}")]
        public async Task<JsonResult> Delete(int id)
        {
            var data = await _service.Delete(id);
            return Json(new
            {
                Success = true,
                Data = data
            });
        }







    }
}
