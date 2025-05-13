using BAL.Interface;
using Entity.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace RealEstate.Controllers
{
    public class UserController : BaseController
    {
        IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }



        public async Task<JsonResult> GetById(int id)
        {
            var data = await _service.GetById(id);
            return Json(data);
        }

        [HttpPost]
        public async Task<JsonResult> GetAll()
        {
            var data = await _service.GetAll();
            return Json(data);
        }

        [HttpPost]
        public async Task<JsonResult> Save([FromBody] UserVM vm)
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
            var data = await _service.Save(vm);
            return Json(data);
        }

        public async Task<JsonResult> Delete(int id)
        {
            var data = await _service.Delete(id);
            return Json(data);
        }



    }
}
