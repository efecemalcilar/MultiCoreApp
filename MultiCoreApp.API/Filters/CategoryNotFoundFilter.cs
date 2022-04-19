using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MultiCoreApp.API.DTOs;
using MultiCoreApp.Core.IntService;

namespace MultiCoreApp.API.Filters
{
    public class CategoryNotFoundFilter:ActionFilterAttribute
    {
        private readonly ICategoryService _catService;

        public CategoryNotFoundFilter(ICategoryService catService)
        {
            _catService = catService;
        }


        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) //Islemin ne arada devreye gireceğini söyleyecez. Amacımız extension yazıp hata kontrollerini takip edecez.
        {
            
            Guid id = (Guid)context.ActionArguments.Values.FirstOrDefault()!; //Unlem null gelme durumunda patlamamasını sağlıyor.

            var cat = await _catService.GetByIdAsync(id);
            if (cat!=null) //Category null değil ise
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 404; //Not Found hata kodu

                errorDto.Errors.Add($"Id'si {id} olan kategori veri tabaninda bulunamadi.");
                context.Result = new NotFoundObjectResult(errorDto); // errorDto yu donmesını ıstıyorum.

            }
        }
    }
}
