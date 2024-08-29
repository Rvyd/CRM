using Entities.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;

namespace CRMApp.Infrastructure.Extensions
{

    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext yapılandırması
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("sqlconnection"),
                b => b.MigrationsAssembly("CRMApp"));

                options.EnableSensitiveDataLogging(true); //hassas bilgileri kontrol etmek için loglara yansıtırız.

            });
        } 

        //Kimlik bilgileriyle alakalı işlemleri yürüteceğimiz metot
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser,IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount=false; //kişi mailini onaylamadığı sürece hesap açtırılmaz
                options.User.RequireUniqueEmail=true; //benzersiz mail adresleri olsun
                options.Password.RequireUppercase=false; //Şifrede büyük harf olmasın
                options.Password.RequireLowercase=false;// küçük harf olmasın
                options.Password.RequireDigit=false;
                options.Password.RequiredLength=6; //şifre uzunluğu

            })
            .AddEntityFrameworkStores<RepositoryContext>();//kendi veri tabanımız
        }

        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {
            //Repository'leri kullanmak istediğimizi belirttik
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ITalkRepository, TalkRepository>();
        }
        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
            //Service'leri kullanmak için
            services.AddScoped<IServiceManager,ServiceManager>();
            services.AddScoped<ICompanyService, CompanyManager>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<ITalkService,TalkManager>();
        }

        public static void ConfigureApplicationCookie(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options=>
            {
                options.LoginPath= new PathString("/Account/Login");
                options.ReturnUrlParameter=CookieAuthenticationDefaults.ReturnUrlParameter;
                options.ExpireTimeSpan=TimeSpan.FromMinutes(10);
                options.AccessDeniedPath=new PathString("/Account/AccessDenied");
            });
        }


    }
}