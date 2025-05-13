using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModel
{
     public class UserVM
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Image {  get; set; }
        public string Role { get; set; }

    }

    public class LoginVM
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }

    
    public class RegisterVM
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

       [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm your Password")]
        public string ConfirmPassword { get; set; }
        public string Role { get; set; } = "User";
    }

}
