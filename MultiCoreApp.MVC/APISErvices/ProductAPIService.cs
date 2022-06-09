using MultiCoreApp.MVC.DTOs;
using Newtonsoft.Json;
using System.Text;

namespace MultiCoreApp.MVC.APISErvices
{
    public class ProductAPIService
    {
        private readonly HttpClient _httpClient;
        public ProductAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            IEnumerable<ProductsWithCategoryDto> productDtos;
            var response = await _httpClient.GetAsync("product"); // api - controllerda verdigim isim neyse o

            if (response.IsSuccessStatusCode)
            {
                productDtos = JsonConvert.DeserializeObject<IEnumerable<ProductsWithCategoryDto>>(await response.Content.ReadAsStringAsync())!;

            }
            else
            {
                productDtos = null;
            }
            return productDtos;

        }
        public async Task<ProductsWithCategoryDto> GetByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"Product/{id}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ProductsWithCategoryDto>(await response.Content.ReadAsStringAsync())!;
            }
            else
            {
                return null!;
            }

        }
        public async Task<ProductsWithCategoryDto> AddAsync(ProductsWithCategoryDto proDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(proDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("product", stringContent);
            if (response.IsSuccessStatusCode)
            {
                proDto = JsonConvert.DeserializeObject<ProductsWithCategoryDto>(await response.Content.ReadAsStringAsync())!;
                return proDto;

            }
            else
            {
                return null!;
            }
        }
        public async Task<bool> Update(ProductsWithCategoryDto proDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(proDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"product", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        public async Task<IEnumerable<ProductsWithCategoryDto>> GetAllWithCategoryAsync()
        {
            IEnumerable<ProductsWithCategoryDto> proDtos;
            var response = await _httpClient.GetAsync("product/categoryall"); // api - controllerda verdigim isim neyse o

            if (response.IsSuccessStatusCode)
            {
                proDtos = JsonConvert.DeserializeObject<IEnumerable<ProductsWithCategoryDto>>(await response.Content.ReadAsStringAsync())!;

            }
            else
            {
                proDtos = null;
            }
            return proDtos;

        }
    }
}
