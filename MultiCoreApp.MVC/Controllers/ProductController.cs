using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.MVC.APISErvices;
using MultiCoreApp.MVC.DTOs;

namespace MultiCoreApp.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ProductAPIService _productAPIService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, ProductAPIService productApiService, IMapper mapper)
        {
            _productService = productService;
            _productAPIService = productApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductDto> pro = await _productAPIService.GetAllAsync();
            return View(pro);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var catDto =
                await _productAPIService.GetByIdAsync(id); //Categoryden category service e gitsin getbyid çalıştırsın
            return View(catDto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            await _productAPIService.AddAsync(productDto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult>
            Update(Guid id) //guncelleme yapmam ıcın once guncelleyeceğim kaydı bulmam gerekiyor.
        {
            var cat = await _productAPIService.GetByIdAsync(id);
            return View(cat);
        }

        [HttpPost]

        public async Task<IActionResult> Update(ProductDto proDto)
        {
            await _productAPIService.Update(proDto);
            return RedirectToAction("Index");
        }
    }
}
