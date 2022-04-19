namespace MultiCoreApp.MVC.DTOs
{
    public class CategoryWithProductsDto:CategoryDto
    {
        // İçeride bir product listesi calısmasını istiyorum. Bizim category de sadece 2 özellik vardı. Biz istedik ki kullanıcıya bütün bilgiler gitsin o yuzden bu class ı oluşturduk.
        public ICollection<ProductDto> Products { get; set; }


    }
}
