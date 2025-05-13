using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model;

namespace DAO.Interface
{
    public interface IImageRepo
    {
        void SaveImage(Image file);
        List<Image> GetAll();
        Image GetById(int id);
        void Update(Image file);
        void Delete(int id);
    }
}
