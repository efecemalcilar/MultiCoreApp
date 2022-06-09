using AutoMapper;
using MultiCoreApp.MVC.DTOs;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.MVC.Mapping
{
    public class MapProfile: Profile // Amacım automapper a hangi tabloları birbiriyle değişecek diye söylemek durumundayım.
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>(); // Category sınıfını categorydto ya dönüştürceksin
            CreateMap<CategoryDto, Category>(); // categorydto yu category e dönüştürceksin

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Category, CategoryWithProductsDto>(); 
            CreateMap<CategoryWithProductsDto, Category>();


            CreateMap<Product, ProductsWithCategoryDto>();
            CreateMap<ProductsWithCategoryDto, Product>();

        }
    }
}
