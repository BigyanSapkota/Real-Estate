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
     public interface IPropertyService
    {
        Task<ResponseData<Property>> Save(PropertyVM vm);
        Task<ResponseData<Property>> Delete(int id);
        Task<ResponseData<List<PropertyVM>>> GetAll(string PropertyName, string PropertyType, string PropertyPrice);
        Task<ResponseData<PropertyVM>> GetById(int id);
        Task<ResponseData<PropertyVM>> GetByType(string type);
    }
}
