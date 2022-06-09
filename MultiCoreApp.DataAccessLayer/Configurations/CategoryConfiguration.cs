using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.DataAccessLayer.Configuration
{
    public class CategoryConfiguration :IEntityTypeConfiguration<Category> //Configuration dosyalarını ekleyebilmek için bu sınıfı çağırmam gerek. Entity Category bu yaptığım fluent apidir. Entity de olusturdugumuz tabloların özellıklerını belirttik.
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.Property(s => s.Id).UseIdentityColumn();
            builder.Property(s => s.Name).IsRequired().HasMaxLength(50); //Bu alan zorunlu bir alan anlamına gelir.
            builder.ToTable("tblCategories");
        }
    }
}
