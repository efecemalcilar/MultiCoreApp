using Microsoft.EntityFrameworkCore;
using MultiCoreApp.Core.IntRepository;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.Core.IntUnitOfWork;
using MultiCoreApp.DataAccessLayer;
using MultiCoreApp.DataAccessLayer.Repository;
using MultiCoreApp.DataAccessLayer.UnitOfWork;
using MultiCoreApp.MVC.APISErvices;
using MultiCoreApp.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient<CategoryAPIService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["baseUrl"]);
});

builder.Services.AddHttpClient<ProductAPIService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["baseUrl"]);
});

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<MultiDbContext>(options =>
{
    //options nesnemizin içerisini dolduracaz.

    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConStr"), sqlServerOptionsAction: sqloptions =>
    {
        sqloptions.EnableRetryOnFailure(); // Bir hata oluþmasý durumunda tekrar tekrar olusturmayý denesin.
        sqloptions.MigrationsAssembly("MultiCoreApp.DataAccessLayer"); //Migration assembly dosyalarýný arka planda tutacagým yeri soyluyorum.
    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
