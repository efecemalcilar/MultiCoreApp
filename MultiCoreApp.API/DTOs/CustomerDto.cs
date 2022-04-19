using System.ComponentModel.DataAnnotations;

namespace MultiCoreApp.API.DTOs
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "{0} alani zorunludur.")]
        public string Name { get; set; }
        
        
    }
}
