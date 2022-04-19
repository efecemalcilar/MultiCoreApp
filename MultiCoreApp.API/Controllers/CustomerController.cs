using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiCoreApp.API.DTOs;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _cusService;
        private IMapper _mapper;

        public CustomerController(ICustomerService cusService, IMapper mapper)
        {
            _cusService = cusService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cus = await _cusService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CustomerDto>>(cus));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var pro = await _cusService.GetByIdAsync(id);

            return Ok(_mapper.Map<CategoryDto>(pro));

        }

        [HttpPost]//Kayıt
        public async Task<IActionResult> Save(ProductDto proDto)
        {
            var newPro = await _cusService.AddAsync(_mapper.Map<Customer>(proDto));
            return Created(string.Empty, _mapper.Map<CategoryDto>(newPro));
        }

        [HttpPut] // Update
        public IActionResult Update(ProductDto proDto)
        {
            var pro = _cusService.Update(_mapper.Map<Customer>(proDto));
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Remove(Guid id)
        {
            var pro = _cusService.GetByIdAsync(id).Result;
            _cusService.Remove(pro);
            return NoContent();
        }

        [HttpDelete("{name}")]
        public IActionResult RemoveByName(string name)
        {
            var pro = _cusService.Where(s => s.Name == name).Result;
            _cusService.RemoveRange(pro);
            return NoContent();
        }


        [HttpGet("{id:guid}/category")] //Category Name gelmesi için.
        public async Task<IActionResult> GetWithProductById(Guid id)
        {
            var pro = await _cusService.GetCustomerByIdAsync(id);
            return Ok(_mapper.Map<ProductsWithCategoryDto>(pro));
        }






    }
}
