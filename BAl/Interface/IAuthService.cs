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
     public interface IAuthService
    {
        Task<ResponseData<User>> Authenticate (string email, string password);
        Task<ResponseData<User>> GetByEmail(string email);
        Task<ResponseData<User>> Register(RegisterVM vm);

    }
}
