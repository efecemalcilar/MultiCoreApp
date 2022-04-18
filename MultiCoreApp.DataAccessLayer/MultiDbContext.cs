using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiCoreApp.Core.Models;
using MultiCoreApp.DataAccessLayer.Configuration;
using MultiCoreApp.DataAccessLayer.Configurations;
using MultiCoreApp.DataAccessLayer.Seeds;

namespace MultiCoreApp.DataAccessLayer
{
    public class MultiDbContext:DbContext
    {
        public MultiDbContext(DbContextOptions<MultiDbContext> options):base(options) //Buraya dışarıdan bir veri alıcam bu veriye options ismini vericem options verisini Base e gödnermem gerekiyor. Burda DbContext benim base classım bunu yapabilmek için options) : base(options diyorum)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var g1 = Guid.NewGuid();
            var g2 = Guid.NewGuid();
            var g3 = Guid.NewGuid();

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            //modelBuilder.Entity<Product>().HasKey(); Böylede yazabilirdim eskiden böyle yazardık ?? 

            modelBuilder.ApplyConfiguration(new ProductSeed(new Guid[] {g1, g2}));
            modelBuilder.ApplyConfiguration(new CategorySeed(new Guid[] {g1, g2}));
        }
    }
}
