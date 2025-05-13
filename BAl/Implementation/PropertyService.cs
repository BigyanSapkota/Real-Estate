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
     public class PropertyService : IPropertyService
    {
        IPropertyRepo _repo;
        public PropertyService(IPropertyRepo repo)
        {
            _repo = repo;
        }



        public async Task<ResponseData<Property>> Delete(int id)
        {

            var data = await _repo.Delete(id);
            return new ResponseData<Property>
            {
                Success = true,
                Message = " Data Deleted Successfully"
            };
        }



        public async Task<ResponseData<List<PropertyVM>>> GetAll(string PropertyName,string PropertyType,string PropertyPrice)
        {
            var data = await _repo.GetAll(PropertyName,PropertyType,PropertyPrice);
            var vm = data.Data.Select(abc => new PropertyVM
            {
                PropertyId = abc.PropertyId,
                PropertyName = abc.PropertyName,
                PropertyType = abc.PropertyType,
                PropertyLocation = abc.PropertyLocation,
                PropertyDescription = abc.PropertyDescription,
                PropertyImage = abc.PropertyImage,
                PropertyPrice = abc.PropertyPrice,
             
          
            })
            .ToList();


            return new ResponseData<List<PropertyVM>>
            {
                Success = true,
                Data = vm
            };
        }



        public async Task<ResponseData<PropertyVM>> GetById(int id)
        {
            var data = await _repo.GetById(id);

            if (data == null || data.Data == null)
            {
                return new ResponseData<PropertyVM>
                {
                    Success = false,
                    Message = "Property not found.",
                    Data = null
                };
            }
            else
            {
                var vm = new PropertyVM
                {
                    PropertyId = data.Data.PropertyId,
                    PropertyName = data.Data.PropertyName,
                    PropertyType = data.Data.PropertyType,
                    PropertyLocation = data.Data.PropertyLocation,
                    PropertyDescription = data.Data.PropertyDescription,
                    PropertyImage = data.Data.PropertyImage,
                    PropertyPrice = data.Data.PropertyPrice
                };
                return new ResponseData<PropertyVM>
                {
                    Success = true,
                    Data = vm
                };
            }
        }



        public async Task<ResponseData<PropertyVM>> GetByType(string type)
        {
            var data = await _repo.GetByType(type);

            if (data == null || data.Data == null)
            {
                return new ResponseData<PropertyVM>
                {
                    Success = false,
                    Message = "Property not found.",
                    Data = null
                };
            }
            else
            {
                var vm = new PropertyVM
                {
                    PropertyId = data.Data.PropertyId,
                    PropertyName = data.Data.PropertyName,
                    PropertyType = data.Data.PropertyType,
                    PropertyLocation = data.Data.PropertyLocation,
                    PropertyDescription = data.Data.PropertyDescription,
                    PropertyImage = data.Data.PropertyImage,
                    PropertyPrice = data.Data.PropertyPrice
                };
                return new ResponseData<PropertyVM>
                {
                    Success = true,
                    Data = vm
                };
            }
        }



        public async Task<ResponseData<Property>> Save(PropertyVM vm)
        {
            if (vm.PropertyId != 0)
            {
                // Await the task to get the actual ResponseData<Property> object  
                var oldData = await _repo.GetById(vm.PropertyId);

                if (oldData != null && oldData.Data != null)
                {
                    oldData.Data.PropertyId = vm.PropertyId;
                    oldData.Data.PropertyName = vm.PropertyName;
                    oldData.Data.PropertyType = vm.PropertyType;
                    oldData.Data.PropertyLocation = vm.PropertyLocation;
                    oldData.Data.PropertyDescription = vm.PropertyDescription;
                    oldData.Data.PropertyImage = vm.PropertyImage;
                    oldData.Data.PropertyPrice = vm.PropertyPrice;

                    return await _repo.Update(oldData.Data);
                }
                else
                {
                    return new ResponseData<Property>
                    {
                        Success = false,
                        Message = "Property not found.",
                        Data = null
                    };
                }
            }
            else
            {
                Property data = new Property()
                {
                    PropertyId = vm.PropertyId,
                    PropertyName = vm.PropertyName,
                    PropertyType = vm.PropertyType,
                    PropertyLocation = vm.PropertyLocation,
                    PropertyDescription = vm.PropertyDescription,
                    PropertyImage = vm.PropertyImage,
                    PropertyPrice = vm.PropertyPrice,
                    isActive = true
                };

                return await _repo.Save(data);
            }
        }
    }

}

