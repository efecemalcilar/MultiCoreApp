using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiCoreApp.Core.IntService;

namespace MultiCoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _catService;

        public CategoryController(ICategoryService catService) //ICategory üzerinden işlem yurutecem o beni categoryservice e götürecek.
        {
            _catService = catService;
        }



        [HttpGet] // Select işlemleri için api de kullanılan Key worddür.

        public async Task<IActionResult> GetAll()
        {
            var cat = await _catService.GetAllAsync();
            return Ok(cat); //Ok 200 değeri geri döner başarılı oldum mesajıdır, benden sonuc bekliyor.

        }

        [HttpGet("{id:guid}")] //Bu id dışında guid kabul etme
        public async Task<IActionResult> GetById(Guid id)
        {
            var cat = await _catService.GetByIdAsync(id);

            return Ok(cat);
        }
    }
}
