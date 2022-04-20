using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MultiCoreApp.API.DTOs;

namespace MultiCoreApp.API.Filters
{
    public class ValidationFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid) //Model statein valid olmadıgı durumlar ıcın
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 400;

                IEnumerable<ModelError> modelErrors = context.ModelState.Values.SelectMany(s => s.Errors); //Hataları modelErrors adında bir nesneye tasıycam. Modelstate butun hepsinde ki hataları kontrol ediyor.

                modelErrors.ToList().ForEach(s =>
                {
                    errorDto.Errors.Add(s.ErrorMessage); //burada errorDto listesindeki hatalar kısmına s.ErrorMessageyi ekle diyoruz.

                });
                context.Result = new BadRequestObjectResult(errorDto);
            }
        }
    }
}
