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

namespace BAL.Implementation
{
    public class UserService : IUserService
    {
        IUserRepo _repo;
        public UserService(IUserRepo repo)
        {
            _repo = repo;
        }

        public Task<ResponseData<User>> Delete(int id)
        {
            return _repo.Delete(id);
        }

        public async Task<ResponseData<List<UserVM>>> GetAll()
        {
            var data = await _repo.GetAll();
            var vm = data.Data.Select(user => new UserVM
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                ConfirmPassword = user.Password, // Assuming ConfirmPassword is same as Password  
                Image = user.Image?.ToString(),
                Role = user.Role?.ToString()
            }).ToList();

            return new ResponseData<List<UserVM>>
            {
                Success = true,
                Data = vm
            };
        }

        public async Task<ResponseData<UserVM>> GetById(int id)
        {
            var data = await _repo.GetById(id);
            var vm = new UserVM
            {
                UserId = data.Data.UserId,
                UserName = data.Data.UserName,
                Email = data.Data.Email,
                Password = data.Data.Password,
                //ConfirmPassword = data.Data.ConfirmPassword,
                Image = data.Data.Image?.ToString(),
                Role = data.Data.Role?.ToString()
            };

            return new ResponseData<UserVM>
            {
                Success = true,
                Data = vm
            };
        }

        public async Task<ResponseData<User>> Save(UserVM vm)
        {
            if (vm.UserId != 0)
            {
                var oldData = await _repo.GetById(vm.UserId);

                oldData.Data.UserName = vm.UserName;
                oldData.Data.Email = vm.Email;
                oldData.Data.Password = vm.Password;
                oldData.Data.Image = (vm.Image).ToString();
                oldData.Data.Role = vm.Role;
                oldData.Data.IsActive = true;

                return await _repo.Update(oldData.Data);
            }
            else
            {
                User data = new User()
                {
                    UserName = vm.UserName,
                    Email = vm.Email,
                    Password = vm.Password,
                    Image = vm.Image,
                    Role = vm.Role,
                    IsActive = true
                };

                return await _repo.Save(data);
            }
        }




    }
}
