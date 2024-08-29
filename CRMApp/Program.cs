using System.Net;
using CRMApp.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;

var builder = WebApplication.CreateBuilder(args);
//api kullanacağımızı belirttik
builder.Services.AddControllers()
 .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
//Configuration işlemlerini bir metota eklemiş olduk
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();
builder.Services.ConfigureApplicationCookie();


builder.Services.AddAutoMapper(typeof(Program));
// SQLite sağlayıcısını başlatma
SQLitePCL.Batteries_V2.Init();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();  //bu sırada olmak zorundalar
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name:"Admin",
       areaName:"Admin",
       pattern:"Admin/{controller=Dashboard}/{action=Index}/{id?}"

    );
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

    endpoints.MapRazorPages();

    endpoints.MapControllers(); //api endpoint
    
});


app.ConfigureAndCheckMigration();
app.ConfigureDefaultAdminUser();
app.MapRazorPages();

app.Run();
