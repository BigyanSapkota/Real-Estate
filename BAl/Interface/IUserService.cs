using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Common;
using Entity.Model;
using Entity.ViewModel;

namespace BAL.Interface
{
     public interface IUserService
    { 
        Task<ResponseData<User>> Save(UserVM vm);
        Task<ResponseData<User>> Delete(int id);
        Task<ResponseData<List<UserVM>>> GetAll();
        Task<ResponseData<UserVM>> GetById(int id);
    }
}
