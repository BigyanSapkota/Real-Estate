using System.Security.Claims;
using BAL.Implementation;
using BAL.Interface;
using DAO;
using DAO.Migrations;
using Entity.Model;
using Entity.ViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace RealEstate.Controllers
{
    public class AuthController : Controller
    {
        IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }


        [HttpGet]   
        public IActionResult Login()
        {
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("Role");
            HttpContext.Session.Remove("Email");
            return View();
        }


        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }


        //[HttpPost]
        //public async Task<ActionResult> Login(string email, string password)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var response = await _service.Authenticate(email, password);
        //        if (response != null && response.Success && response.Data != null)
        //        {
        //            var user = response.Data;
        //            HttpContext.Session.SetString("UserId", user.UserId.ToString());
        //            HttpContext.Session.SetString("Role", user.Role);
        //            HttpContext.Session.SetString("Email", user.Email);
        //            return RedirectToAction("Index", "Home");
        //        }
        //        ViewBag.Error = "Invalid email or password.";
        //    }
        //    return View();
        //}



        [HttpPost]
        public async Task<ActionResult> Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var response = await _service.Authenticate(email, password);
                if (response != null && response.Success && response.Data != null)
                {
                    var user = response.Data;

                    // Setup claims
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("UserId", user.UserId.ToString())
            };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                    );
                    var role = HttpContext.Session.GetString("Role");

                   return RedirectToAction("Index", "Home");
                    
                
                    
                }

                ViewBag.Error = "Invalid email or password.";
            }
            return View();
        }


    
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }
        




        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            if (vm.Password != vm.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Passwords do not match.");
                return View(vm);
            }

            var response = await _service.GetByEmail(vm.Email);
            if (response != null && response.Success && response.Data != null)
            {
                ModelState.AddModelError("Email", "Email already exists.");
                return View(vm);
            }
            else
            {
                var registerResponse = await _service.Register(vm);
                if (registerResponse != null && registerResponse.Success && registerResponse.Data != null)
                {
                    var user = registerResponse.Data;
                    HttpContext.Session.SetString("UserId", user.UserId.ToString());
                    HttpContext.Session.SetString("Role", user.Role);
                    HttpContext.Session.SetString("Email", user.Email);

                    return RedirectToAction("Index", "Home");
                }
                ViewBag.Error = "Registration failed."; 
                return View(vm);
            }
        }







    }
}
