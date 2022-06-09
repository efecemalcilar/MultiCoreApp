using System.ComponentModel.DataAnnotations;

namespace MultiCoreApp.MVC.DTOs
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "{0} alani zorunludur.")]
        public string Name { get; set; }
        
        
    }
}
