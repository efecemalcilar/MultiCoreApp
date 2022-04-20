using System.Reflection.Metadata.Ecma335;
using System.Text;
using MultiCoreApp.MVC.DTOs;
using Newtonsoft.Json;

namespace MultiCoreApp.MVC.APISErvices
{
    public class CategoryAPIService
    {
        private readonly HttpClient _httpClient;

        public CategoryAPIService(HttpClient httpClient)//Dependency Injection
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()//CategoryDto dan oluşturulmuş IEnumerable tipinde ve Adına GETALLAsync dediğim bir method tanımlaması
        {
            IEnumerable<CategoryDto> categoryDtos;
            var response = await _httpClient.GetAsync("category");//api/categories adresine get isteği gönderiyoruz.Category Controller ına gideceği için Category olarak yazdık.
            if (response.IsSuccessStatusCode) // Burası true ise gelen datayı categoryDtos a yönlendirmem gerekiyor. Gelen bilgileri Json Tipinden class tipine cevirmem lazım
            {
                categoryDtos = JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(await response.Content.ReadAsStringAsync())!;//Json tipinden CategoryDto tipine çeviriyoruz.
            }
            else
            {
                categoryDtos = null;
            }

            return categoryDtos;
        }

        public async Task<CategoryDto> GetByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"category/{id}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<CategoryDto>(await response.Content.ReadAsStringAsync())!;
            }
            else
            {
                return null!;
            }
        }

        public async Task<CategoryDto> AddAsync(CategoryDto catDto) // Veriyi categoryDto dan alıp catDto olarak turettik.
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(catDto), Encoding.UTF8, "application/json");//Json tipinden stringeContent çeviriyoruz.
            
            var response = await _httpClient.PostAsync("category", stringContent);//Post isteği gönderiyoruz.
            
            
            //Post işleminin gerçekleştirdim ordan bir sonuc dondu ve o sonucu tekrardan donduruyorum.
            if (response.IsSuccessStatusCode)
            {
                 catDto=JsonConvert.DeserializeObject<CategoryDto>(await response.Content.ReadAsStringAsync())!;//Json tipinden CategoryDto tipine çeviriyoruz.
                 return catDto;
            }
            else
            {
                return null!;
            }
            {
                
            }
        }

        public async Task<bool> Update(CategoryDto catDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(catDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"category", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
