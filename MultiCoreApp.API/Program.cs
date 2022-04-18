//Buras� program�m�n in�aa edildi�i yer. SQL mi oracle mi detaylar� burada bulunuyor. 


using Microsoft.EntityFrameworkCore;
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

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // Request edildi�inde 1 kere Repository olu�tur. Ba�lang�cta tek bir i�lem oldugu i�in scope di�erek bir kere olu�turmas�n� istiyorum

builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


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

builder.Services.AddControllers(); // Burada sadece controller kullanaca��m� soyluyorum
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); //AddPoiint dedi�i bizim rootumuz. 
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // MW i�idir Middle Ware 

app.UseAuthorization(); // Kullan�c� istekde bulundu ben cevap verebilmek i�in on kontrole ihtiyac�m vard�r. Bu kontrol de kullan�c�n�n buna yetkisi var m� yok mu �eklindedir. Bu katman ki�inin yetkili mi yetkisiz mi olduguna karar verdi�imiz katmand�r.

app.MapControllers(); //Burada Kullan�c�n�n iste�ini ben i�eride nas�l y�neticeme�imi s�ylerim.

app.Run();
