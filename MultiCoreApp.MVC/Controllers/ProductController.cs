using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.MVC.APISErvices;
using MultiCoreApp.MVC.DTOs;

namespace MultiCoreApp.MVC.Controllers
{
    public class ProductController : Controller
    {
        
        private readonly ProductAPIService _proApiService;
        private readonly CategoryAPIService _catApiService;
        private readonly IMapper _iMapper;
        public ProductController( ProductAPIService productApiService, IMapper imapper, CategoryAPIService categoryApiService)
        {
            _proApiService = productApiService;
            _iMapper = imapper;
            _catApiService = categoryApiService;
        }
        public async Task<IActionResult> Index()
        {
            var pro = await _proApiService.GetAllWithCategoryAsync();
            return View(pro);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var proDto = await _proApiService.GetByIdAsync(id);
            return View(proDto);
        }
        public IActionResult Create()
        {
            var cat = _catApiService.GetAllAsync().Result;
            ViewData["CategoryId"] = new SelectList(cat, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductsWithCategoryDto proDto)
        {
            if (ModelState.IsValid)
            {
                await _proApiService.AddAsync(proDto);
                return RedirectToAction("Index");
            }
            ViewData["CategoryId"] = new SelectList(_catApiService.GetAllAsync().Result, "Id", "Name", proDto.CategoryId);

            return View(proDto);


        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var proDto = await _proApiService.GetByIdAsync(id);
            ViewData["CategoryId"] = new SelectList(_catApiService.GetAllAsync().Result, "Id", "Name", proDto.CategoryId);
            return View(proDto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductsWithCategoryDto proDto)
        {
            ModelState.Remove("Category");
            if (ModelState.IsValid)
            {
                await _proApiService.Update(proDto);
                return RedirectToAction("Index");
            }
            ViewData["CategoryId"] = new SelectList(_catApiService.GetAllAsync().Result, "Id", "Name", proDto.CategoryId);
            return View(proDto);

        }

    }
}
