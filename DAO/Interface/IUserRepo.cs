using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Common;
using Entity.Model;

namespace DAO.Interface
{
     public interface IUserRepo
    {
        Task<ResponseData<User>> Save(User mdl);
        Task<ResponseData<User>> Delete(int id);
        Task<ResponseData<User>> Update(User mdl);
        Task<ResponseData<List<User>>> GetAll();
        Task<ResponseData<User>> GetById(int id);
        Task<ResponseData<User>> GetByEmail(string email);

    }
}
