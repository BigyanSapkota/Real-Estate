using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
     public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        { }

        public DbSet<User> User { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<Image> Image { get; set; }




    }
}
