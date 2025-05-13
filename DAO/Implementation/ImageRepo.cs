using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Interface;
using Entity.Model;

namespace DAO.Implementation
{
     public class ImageRepo : IImageRepo
    {
        ApplicationDbContext _context;
        public ImageRepo(ApplicationDbContext context)
        {
            _context = context;
        }


        public void SaveImage(Image file)
        {
            _context.Image.Add(file);
            _context.SaveChanges();
        }


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Image> GetAll()
        {
            throw new NotImplementedException();
        }

        public Image GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Image file)
        {
            throw new NotImplementedException();
        }
    }
}
