using Microsoft.AspNetCore.Diagnostics;
using MultiCoreApp.API.DTOs;
using Newtonsoft.Json;

namespace MultiCoreApp.API.Extensions
{
    public static class UseCustomExtensionsHandler // Amacı araya girip çıkma. Araya girip cıktıgı için service değilde middware olacak. Request ve response arasında araya girip işini bitirip çıkacak.
    {
        public static void UseCustomException(this IApplicationBuilder app) //Application builderden app olarak alacaz veriyi. This dememin sebebi burda ki yapıyı applicationbuilder da kullanacağımı söylüyorum.
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500; // Context içeriğinden yani db den gelen 500 hata kodu sunucudan geliyor. Sistem 500 hatası veriyor ben onu yakalayıp kendi 500 hatama cevirdim.
                    context.Response.ContentType = "application/json";
                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        var ex = error.Error;
                        if (ex != null)
                        {
                            ErrorDto errorDto = new ErrorDto(); // Burda ErrrDto calssında olusturdugum veriyi API de gösterebilmek için Json a ceviriyorum.
                            errorDto.Status = 500;
                            errorDto.Errors.Add(ex.Message);
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDto));
                        }
                    }
                });
            });
        }
    }
}
