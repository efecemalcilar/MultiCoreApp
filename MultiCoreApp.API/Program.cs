//Buras� program�m�n in�aa edildi�i yer. SQL mi oracle mi detaylar� burada bulunuyor. 


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


//Life Cycle (Alttakiler) ==> ili�kili kodun ya�am s�resi , request ile response aras�nda ge�en s�re (Kodun tetiklenmesi)


builder.Services.AddAutoMapper(typeof(Program)); // Amac�m�z kullanacag�m�z servisleri tetiklemek. bu �al���nca Automapper aktif hala gelecek. Program.cs in g�revi �al��mas�n� istedi�imiz �eyleri tetiklemek.

builder.Services.AddScoped<CategoryNotFoundFilter>(); // Islem cal�s�t�nga categorynotfound filter da cal�sacak.

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // Request edildi�inde 1 kere Repository olu�tur. Ba�lang�cta tek bir i�lem oldugu i�in scope di�erek bir kere olu�turmas�n� istiyorum

builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();


/*builder.Services.AddTransient(typeof(IRepository<>), typeof(IRepository<>));*/     // Repository cagr�lacaksa her seferinde tekrardan cag�r demek. Request ve response aras�nda. Her Defas�nda newleyip yeni veriyle �al��mak i�in kullan�yorum.

/*builder.Services.AddSingleton(typeof(IRepository<>), typeof(IRepository<>));*/     // Ko�ul ne olursa olsun sadece bir kere olusturacak. Guncellenmeyen bir verim varsa s�rekli ayn� veriyi �ekiyorsam Singleton tercih ederim


builder.Services.AddDbContext<MultiDbContext>(options =>
{
    //options nesnemizin i�erisini dolduracaz.

    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConStr"),sqlServerOptionsAction: sqloptions =>
    {
        sqloptions.EnableRetryOnFailure(); // Bir hata olu�mas� durumunda tekrar tekrar olusturmay� denesin.
        sqloptions.MigrationsAssembly("MultiCoreApp.DataAccessLayer"); //Migration assembly dosyalar�n� arka planda tutacag�m yeri soyluyorum.
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

// Buras� accestoken olusturulurken kullan�lacak o yuzden ayri bir tan�mlama yapt�k.
builder.Services.Configure<CustomTokenOptions>(builder.Configuration.GetSection("TokenOption"));




//Builder.Configuration dersek biz App Settings e gitmi� oluyoruz. Burasi authentication ile cal�sacak 
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
    o.Filters.Add(new ValidationFilter()); // Validation Filter � butun controller �c�ne eklemi� oldum

}); // Burada sadece controller kullanaca��m� soyluyorum
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); //AddPoiint dedi�i bizim rootumuz. 
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

//Burada her �ey s�rayla �al���r a��a��ya inerken request yukar� c�karken response u tamamlar.

app.UseCustomException();
app.UseHttpsRedirection(); // MW i�idir Middle Ware 
app.UseAuthentication(); //
app.UseCors(MyAllowSpesificOrigins);
app.UseAuthorization(); // Kullan�c� istekde bulundu ben cevap verebilmek i�in on kontrole ihtiyac�m vard�r. Bu kontrol de kullan�c�n�n buna yetkisi var m� yok mu �eklindedir. Bu katman ki�inin yetkili mi yetkisiz mi olduguna karar verdi�imiz katmand�r.

app.MapControllers(); //Burada Kullan�c�n�n iste�ini ben i�eride nas�l y�neticeme�imi s�ylerim.

app.Run();

