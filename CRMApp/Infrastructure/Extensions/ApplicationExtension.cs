using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace CRMApp.Infrastructure.Extensions
{
    
    public static class ApplicationExtension
    {
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {
            RepositoryContext  context = app
             .ApplicationServices
             .CreateScope()
             .ServiceProvider
             .GetRequiredService<RepositoryContext>();

 
               //Migration işleminden sonra update database demeye gerek yok artık
             if(context.Database.GetPendingMigrations().Any())
             {
                context.Database.Migrate();
             }
        }
    
       public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
       {
         const string adminUser="Admin"; //kullanıcı adı
         const string adminPassword="Admin+123456";  //ve şifresi

         UserManager<IdentityUser> userManager=app
            .ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<UserManager<IdentityUser>>();

          //admine bütün rolleri vermek için tanımladık
          
          RoleManager<IdentityRole> roleManager=app
          .ApplicationServices
          .CreateAsyncScope()
          .ServiceProvider
          .GetRequiredService<RoleManager<IdentityRole>>();
            //kullanıcının var olup olmadığını kontrol ediyoruz
          IdentityUser user= await userManager.FindByNameAsync(adminUser);
         if(user is null)
         {
            user=new IdentityUser()
            {
                Email="ado@gmail.com.tr",
                PhoneNumber="5061112233",
                UserName=adminUser,

            };
            //kaydı eklemek için
            var result=await userManager.CreateAsync(user,adminPassword);
            if(!result.Succeeded)
              throw new Exception("Admin user could not created");

            var roleResult=await userManager.AddToRolesAsync(user,
              roleManager
               .Roles
                .Select(r=>r.Name)
                .ToList()

            );
            if(!roleResult.Succeeded)
             throw new Exception("System have problems with role defination for admin");

             
        
         }
        
       
       }
   
    }
}