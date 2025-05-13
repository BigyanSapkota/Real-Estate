using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interface;
using DAO.Interface;
using Entity.Common;
using Entity.Model;
using Entity.ViewModel;
using Microsoft.Identity.Client;

namespace BAL.Implementation
{
    public class AuthService : IAuthService
    {
        IUserRepo _repo;
        public AuthService(IUserRepo repo)
        {
            _repo = repo;
        }

        public async Task<ResponseData<User>> Authenticate(string email, string password)
        {
            var response = await _repo.GetByEmail(email);
            if (response != null && response.Data != null && response.Data.Password == password)
            {
                return new ResponseData<User>
                {
                    Success = true,
                    Data = response.Data,
                };
            }
            return new ResponseData<User>
            {
                Success = false,
                Message = "Invalid email or password"
            };
        }

        public async Task<ResponseData<User>> GetByEmail(string email)
        {
            return await _repo.GetByEmail(email);
        }


        public  async Task<ResponseData<User>> Register(RegisterVM vm)
        {
            var user = new User
            {
                UserName = $"{vm.FirstName} {vm.LastName}",
                Email = vm.Email,
                Password = vm.Password,
                Role = vm.Role,
                Image = "~/Upload_Image/default.webp",
                IsActive = true
            };
            var response = await _repo.Save(user);
            if (response != null && response.Success)
            {
                return new ResponseData<User>
                {
                    Success = true,
                    Data = response.Data,
                    Message = "User registered successfully."
                };
            }
            return new ResponseData<User>
            {
                Success = false,
                Message = "Registration failed."
            };
        }












    }
}
