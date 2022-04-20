using System.ComponentModel.DataAnnotations;

namespace MultiCoreApp.API.DTOs
{
    public class ProductDto // Kullanıcının göreceği alan olacak.
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "{0} alani zorunludur")]
        public string Name { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "{0} alanı 0'dan büyük bir değer olmalıdır.")]
        public int Stock { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "{0} alanı 0'dan büyük bir değer olmalıdır.")]
        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }
    }
}
