using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.MVC.APISErvices;
using MultiCoreApp.MVC.DTOs;

namespace MultiCoreApp.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly CategoryAPIService _categoryAPIService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper, CategoryAPIService categoryApiService) // Dependency Injection
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _categoryAPIService = categoryApiService;
        }

        public async Task<IActionResult> Index()
        {
            //var categories = await _categoryService.GetAllAsync(); // Burda catgeoryservice i tetikledik, ben bunu tetiklemek değil de API üzerinde ki GetAll fonksiyonunu tetiklicem.
           
            IEnumerable<CategoryDto> cat = await _categoryAPIService.GetAllAsync();

            //return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));

            return View(cat);

        }

        public async Task<IActionResult> Details(Guid id)
        {
            var catDto = await _categoryAPIService.GetByIdAsync(id); //Categoryden category service e gitsin getbyid çalıştırsın
            return View(catDto);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryAPIService.AddAsync(categoryDto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(Guid id) //guncelleme yapmam ıcın once guncelleyeceğim kaydı bulmam gerekiyor.
        {
            var cat = await _categoryAPIService.GetByIdAsync(id);
            return View(cat);
        }

        [HttpPost]

        public async Task<IActionResult> Update(CategoryDto catDto)
        {
            await _categoryAPIService.Update(catDto);
            return RedirectToAction("Index");
        }

    }
}
