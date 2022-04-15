using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.DataAccessLayer.Seeds
{
    public class ProductSeed:IEntityTypeConfiguration<Product>
    {
        private readonly Guid[] _guids;

        public ProductSeed(Guid[] guids)
        {
            _guids = guids;
        }
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
            
                new Product{Id = Guid.NewGuid() , Stock = 100,Name = "Dolma kalem" , Price = 122.53m , CategoryId = _guids[0]},
                new Product{Id = Guid.NewGuid() , Stock = 100,Name = "Tukenmez kalem" , Price = 18.06m , CategoryId = _guids[0]},
                new Product{Id = Guid.NewGuid() , Stock = 100,Name = "Kursun Kalem" , Price = 62.19m , CategoryId = _guids[0]},
                new Product { Id = Guid.NewGuid(), Stock = 100, Name = "Çizgili Defter", Price = 22.53m, CategoryId = _guids[1] },
                new Product { Id = Guid.NewGuid(), Stock = 100, Name = "Kareli Defter", Price = 28.06m, CategoryId = _guids[1] },
                new Product { Id = Guid.NewGuid(), Name = "Dumduz defter", Price = 12.19m, CategoryId = _guids[1] }



                );
        }
    }
}
