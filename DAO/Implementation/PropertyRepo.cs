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
     public class PropertyRepo : IPropertyRepo
    {
        ApplicationDbContext _context;
        public PropertyRepo(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<ResponseData<Property>> Delete(int id)
        {
            var data = await _context.Property
             .Where(x => x.PropertyId == id && x.isActive == true)
             .FirstOrDefaultAsync();

            if (data == null)
            {
                return new ResponseData<Property>
                {
                    Success = false,
                    Message = "Data not found in database"
                };
            }
            else
            {
                data.isActive = false;
                await _context.SaveChangesAsync();
                return new ResponseData<Property>
                {
                    Success = true,
                    Message = " Deleted successfully."
                };
            }
        }



        public async Task<ResponseData<List<Property>>> GetAll(string PropertyName, string PropertyType, string PropertyPrice)
        {
            var data = await _context.Property
                       .Where(x => x.isActive == true
                       && (string.IsNullOrEmpty(PropertyName) || x.PropertyName.Contains(PropertyName))
                       && (string.IsNullOrEmpty(PropertyType) || x.PropertyType.Contains(PropertyType))
                       && (string.IsNullOrEmpty(PropertyPrice) || x.PropertyPrice.ToString().Contains(PropertyPrice))
                       )
                       .ToListAsync();
          
            return new ResponseData<List<Property>>
            {
                Success = true,
                Data = data
            };
        }




        public async Task<ResponseData<Property>> GetById(int id)
        {
            var data = await _context.Property
                      .Where(xyz => xyz.isActive == true
                              && xyz.PropertyId == id)
                      .FirstOrDefaultAsync();

            if (data == null)
            {
                return new ResponseData<Property>
                {
                    Success = false,
                    Message = "Property not found."
                };
            }

            return new ResponseData<Property>
            {
                Success = true,
                Data = data
            };

        }



        public async Task<ResponseData<Property>> GetByType(string type)
        {
            var data = await _context.Property
                     .Where(xyz => xyz.isActive == true
                             && xyz.PropertyType == type)
                     .FirstOrDefaultAsync();

            return new ResponseData<Property>
            {
                Success = true,
                Data = data
            };
        }





        public async Task<ResponseData<Property>> Save(Property mdl)
        {
           await _context.AddAsync(mdl);
           await _context.SaveChangesAsync();
            return new ResponseData<Property>
            {
                Success = true,
                Message = "Data Save Successfully",
                Data = mdl
            };
        }



        
        public async Task<ResponseData<Property>> Update(Property mdl)
        {
            await _context.SaveChangesAsync();
            return  new ResponseData<Property>
            {
                Success = true,
                Message = "Data Updated Successfully"
            };
        }
    }
}
