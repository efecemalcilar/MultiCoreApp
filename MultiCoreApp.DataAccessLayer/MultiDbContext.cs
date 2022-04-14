using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.DataAccessLayer
{
    public class MultiDbContext:DbContext
    {
        public MultiDbContext(DbContextOptions<MultiDbContext> options):base(options) //Buraya dışarıdan bir veri alıcam bu veriye options ismini vericem options verisini Base e gödnermem gerekiyor. Burda DbContext benim base classım bunu yapabilmek için options) : base(options diyorum)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
