using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RealEstate.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // check if values exists in session
            // if values exists then open the page
            // else redirect to login page

            string? userId = HttpContext.Session.GetString("UserId");
            string? role = HttpContext.Session.GetString("Role");
            string? email = HttpContext.Session.GetString("Email");

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(role) || string.IsNullOrEmpty(email))
            {
                context.Result = new RedirectResult("/Auth/Login");
            }
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

    }
}
