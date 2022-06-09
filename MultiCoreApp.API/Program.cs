//Burasý programýmýn inþaa edildiði yer. SQL mi oracle mi detaylarý burada bulunuyor. 


using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MultiCoreApp.API.Extensions;
using MultiCoreApp.API.Filters;
using MultiCoreApp.API.Security;
using MultiCoreApp.Core.IntRepository;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.Core.IntUnitOfWork;
using MultiCoreApp.DataAccessLayer;
using MultiCoreApp.DataAccessLayer.Repository;
using MultiCoreApp.DataAccessLayer.UnitOfWork;
using MultiCoreApp.Service.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.


//Life Cycle (Alttakiler) ==> iliþkili kodun yaþam süresi , request ile response arasýnda geçen süre (Kodun tetiklenmesi)


builder.Services.AddAutoMapper(typeof(Program)); // Amacýmýz kullanacagýmýz servisleri tetiklemek. bu çalýþýnca Automapper aktif hala gelecek. Program.cs in görevi çalýþmasýný istediðimiz þeyleri tetiklemek.

builder.Services.AddScoped<CategoryNotFoundFilter>(); // Islem calýsýtýnga categorynotfound filter da calýsacak.

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // Request edildiðinde 1 kere Repository oluþtur. Baþlangýcta tek bir iþlem oldugu için scope diðerek bir kere oluþturmasýný istiyorum

builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();


/*builder.Services.AddTransient(typeof(IRepository<>), typeof(IRepository<>));*/     // Repository cagrýlacaksa her seferinde tekrardan cagýr demek. Request ve response arasýnda. Her Defasýnda newleyip yeni veriyle çalýþmak için kullanýyorum.

/*builder.Services.AddSingleton(typeof(IRepository<>), typeof(IRepository<>));*/     // Koþul ne olursa olsun sadece bir kere olusturacak. Guncellenmeyen bir verim varsa sürekli ayný veriyi çekiyorsam Singleton tercih ederim


builder.Services.AddDbContext<MultiDbContext>(options =>
{
    //options nesnemizin içerisini dolduracaz.

    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConStr"),sqlServerOptionsAction: sqloptions =>
    {
        sqloptions.EnableRetryOnFailure(); // Bir hata oluþmasý durumunda tekrar tekrar olusturmayý denesin.
        sqloptions.MigrationsAssembly("MultiCoreApp.DataAccessLayer"); //Migration assembly dosyalarýný arka planda tutacagým yeri soyluyorum.
    });

});

var MyAllowSpesificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpesificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:3000");

        });
});

// Burasý accestoken olusturulurken kullanýlacak o yuzden ayri bir tanýmlama yaptýk.
builder.Services.Configure<CustomTokenOptions>(builder.Configuration.GetSection("TokenOption"));




//Builder.Configuration dersek biz App Settings e gitmiþ oluyoruz. Burasi authentication ile calýsacak 
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
{
    var tokenOptions = builder.Configuration.GetSection("TokenOption").Get<CustomTokenOptions>();

    opts.TokenValidationParameters = new TokenValidationParameters()
    {

        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        IssuerSigningKey = SignHandler.GetSymmetricSecurityKey(tokenOptions.SecurityKey),


        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        
    };
});

builder.Services.AddControllers(o =>
{
    o.Filters.Add(new ValidationFilter()); // Validation Filter ý butun controller ýcýne eklemiþ oldum

}); // Burada sadece controller kullanacaðýmý soyluyorum
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); //AddPoiint dediði bizim rootumuz. 
builder.Services.AddSwaggerGen();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter=true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Burada her þey sýrayla çalýþýr aþþaðýya inerken request yukarý cýkarken response u tamamlar.

app.UseCustomException();
app.UseHttpsRedirection(); // MW iþidir Middle Ware 
app.UseAuthentication(); //
app.UseCors(MyAllowSpesificOrigins);
app.UseAuthorization(); // Kullanýcý istekde bulundu ben cevap verebilmek için on kontrole ihtiyacým vardýr. Bu kontrol de kullanýcýnýn buna yetkisi var mý yok mu þeklindedir. Bu katman kiþinin yetkili mi yetkisiz mi olduguna karar verdiðimiz katmandýr.

app.MapControllers(); //Burada Kullanýcýnýn isteðini ben içeride nasýl yöneticemeðimi söylerim.

app.Run();

