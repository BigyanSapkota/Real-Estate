using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Interface;
using Entity.Common;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace DAO.Implementation
{
     public class UserRepo : IUserRepo
    {
        ApplicationDbContext _context;
        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<ResponseData<User>> Delete(int id)
        {
            var data = await _context.User
                      .Where(x => x.UserId == id && x.IsActive == true)
                      .FirstOrDefaultAsync();

            if (data == null)
            {
                return new ResponseData<User>
                {
                    Success = false,
                    Message = "User not found in database"
                };
            }
            else
            {
                data.IsActive = false;
                await _context.SaveChangesAsync();
                return new ResponseData<User>
                {
                    Success = true,
                    Message = "User deleted successfully."
                };
            }
        }



        public async Task<ResponseData<List<User>>> GetAll()
        {
            var data = await _context.User.Where(x => x.IsActive == true ).ToListAsync();

            return new ResponseData<List<User>>
            {
                Success = true,
                Data = data
            };
        }
        


        public async Task<ResponseData<User>> GetByEmail(string email)
        {
            var data = await _context.User.Where(x => x.IsActive == true && x.Email == email).FirstOrDefaultAsync();
            return new ResponseData<User>
            {

                Data = data
            };
        }



        public async Task<ResponseData<User>> GetById(int id)
        {
            var data = await _context.User
                       .Where(x => x.UserId == id && x.IsActive == true)
                       .FirstOrDefaultAsync();

            return new ResponseData<User>
            {
                Success = true,
                Data = data
            };
        }



        public async Task<ResponseData<User>> Save(User mdl)
        {
            await _context.AddAsync(mdl);
            await _context.SaveChangesAsync();
            return new ResponseData<User>
            {
                Success = true,
                Message = "Data Save Successfully"
            };
        }



        public async Task<ResponseData<User>> Update(User mdl)
        {
             await _context.SaveChangesAsync();
            return new ResponseData<User>
            {
                Success = true,
                Message = "User Updated Successfully"
            };
        }


    }
}
