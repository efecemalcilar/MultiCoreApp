using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiCoreApp.API.DTOs;
using MultiCoreApp.API.Filters;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.API.Controllers
{
    [ValidationFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _catService;
        private IMapper _mapper;

        public CategoryController(ICategoryService catService, IMapper mapper) //ICategory üzerinden işlem yurutecem o beni categoryservice e götürecek.
        {
            _catService = catService;
            _mapper = mapper;
        }



        [HttpGet] // Select işlemleri için api de kullanılan Key worddür.

        public async Task<IActionResult> GetAll()
        {
            var cat = await _catService.GetAllAsync();
           
            //return Ok(cat); //Ok 200 değeri geri döner başarılı oldum mesajıdır, benden sonuc bekliyor.
           
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(cat)); //Bütün verileri liste tipinde cekeceksem IEnumarable olmalı Burda catin içeriisnde ki verileri dto ya cevir diyor.


        }
        [ServiceFilter(typeof(CategoryNotFoundFilter))] // Bu Filter sadece bunun için calıştır dedik.

        [HttpGet("{id:guid}")] //Bu id dışında guid kabul etme
        public async Task<IActionResult> GetById(Guid id)
        {
            var cat = await _catService.GetByIdAsync(id);

            return Ok(_mapper.Map<CategoryDto>(cat)); //Cat nesnemi categorydto ya çevirip kullanıcıya o şekilde göndericem

        }

        [HttpPost] //Kayıt işlemi için HttpPost demeliyim API kuralı
        public async Task<IActionResult> Save(CategoryDto catDto) //Kullanıcan categorydto tipinde veri gelecek. Bunu db ye kaydetem lazım dto dan category e cevirmem lazım. Burda Addasync işlemi uyguluyorum.
        {
            var newCat = await _catService.AddAsync(_mapper.Map<Category>(catDto)); //Kayıt işleminde Addasync kullanıcam
            
            return Created(string.Empty, _mapper.Map<CategoryDto>(newCat));
        }

        [HttpPut] //Update işlemidir , update için async yoktur.
        public IActionResult Update(CategoryDto catDto)
        {
            var cat = _catService.Update(_mapper.Map<Category>(catDto));
            return NoContent();
        }


        [HttpDelete("{id:guid}")] // Id zorunlulugunu biz verdik.
        public IActionResult Remove(Guid id) // Kullanıcı tarafından tetiklenecek method.
        {
            var cat = _catService.GetByIdAsync(id).Result; // Once id verisini bulmam lazım burda id verisini gönderip cat in içine aldık.
            _catService.Remove(cat);
            return NoContent();
            // :Asenkron metodlar bekletmek ister asenkron olmayanlar hemen calısmak ister. Deletede de asnyc kullanamadıgımız için sadece sonucu döndür diyerek . Result diyoruz ki iş bittiğinde bana sonucu dondursun.
        }


        [HttpDelete("{name :alpha}")]
        public IActionResult RemoveByName(string name)
        {
            var cat = _catService.Where(s => s.Name == name).Result;
            _catService.RemoveRange(cat); // RemoveRange çoklu kayıt silmedir.
            return NoContent();
        }


        [HttpGet("{id:guid}/products")] //Category i getir ürünleriyle birlikte deriz. diğerlerinden farkı Get işleminin farklı yazılmasıdır.
        public async Task<IActionResult> GetWithProductById(Guid id)
        {
            var cat = await _catService.GetWithProductByIdAsync(id);
            return Ok(_mapper.Map<CategoryWithProductsDto>(cat)); //cat nesnesini al categorydto ya döndür diyorum. Dönüşte kullanıcıya 1 sonuç dönecek.
        }



    }
}
