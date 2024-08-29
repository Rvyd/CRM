using CRMApp.Models;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CRMApp.Controllers
{
    public class AccountController:Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager=signInManager;
        }

        public IActionResult Login()
        {
             return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //asekron yapılarda kullanım bu şekilde olur
         public async  Task<IActionResult> Login([FromForm] LoginModel model)
        {
            if(ModelState.IsValid) //alanların doldurulup doldurulmadığı kısımları
            {
                IdentityUser user= await _userManager.FindByNameAsync(model.Name); //veri tabanında olan isimlerden gelen isim var mı ona bakar
                if(user is not null) //kullanıcı bulundu
                {
                    
                    await _signInManager.SignOutAsync(); //aktif oturum sonlandırıldı
                     if ((await _signInManager.PasswordSignInAsync(user, model.Password, false, false)).Succeeded)
                    {
                        return Redirect("/Home/Index");
                    }
                }
                ModelState.AddModelError("Error","Kullanacı adı veya şifre yanlış");
           
            }
             return View();
        }
   
       public async  Task<IActionResult> Logout([FromQuery(Name ="ReturnUrl")]string ReturnUrl="/")
       {
             await _signInManager.SignOutAsync();
             return RedirectToAction("Login");
       }

       public IActionResult Register()
       {
         return View();
       }
      [HttpPost]
      [ValidateAntiForgeryToken]
       public async Task<IActionResult> Register([FromForm] RegisterDto model)
       {
         var user=new IdentityUser  //kullanıcı oluşturduk
         {
            UserName=model.UserName,
            Email=model.Email,
         };

          var result= await _userManager  //kullanıcıyı ekledik
            .CreateAsync(user,model.Password);

            if(result.Succeeded)     //kullanıcıya rol yetkisi verdik
            {
                var roleResult = await _userManager
                 .AddToRoleAsync(user,"User");
                 if(roleResult.Succeeded)
                   RedirectToAction("Login");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
            }

            return View();
       }

       public IActionResult AccessDenied([FromQuery(Name ="ReturnUrl")] string returnUrl)
      {
          return View();
      }
   
    }
}