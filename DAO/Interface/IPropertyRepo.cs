using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Common;
using Entity.Model;

namespace DAO.Interface
{
     public interface IPropertyRepo
    {
        Task<ResponseData<Property>> Save(Property mdl);
        Task<ResponseData<Property>> Delete(int id);
        Task<ResponseData<Property>> Update(Property mdl);
        Task<ResponseData<List<Property>>> GetAll(string PropertyName, string PropertyType, string PropertyPrice);
        Task<ResponseData<Property>> GetById(int id);
        Task<ResponseData<Property>> GetByType(string type);
    }
}
