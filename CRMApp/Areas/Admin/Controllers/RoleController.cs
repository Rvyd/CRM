using CRMApp.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace CRMApp.Areas.Admin.Controllers
{
      [Area("Admin")]
      [Authorize(Roles ="Admin")]
    public class RoleController:Controller
    {

        private readonly IServiceManager _manager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        public RoleController(IServiceManager manager, RoleManager<IdentityRole> rolemanager)
        {
            _manager = manager;
            _rolemanager = rolemanager;
        }

        public IActionResult Index()
        {
            return View(_manager.AuthService.Roles); //sayfaya rolleri göndeririyoruz
        }
        
         [HttpGet]
          public IActionResult AddRole()
         {
            return View();
         }

         [HttpPost]
         [ValidateAntiForgeryToken]
          public async Task<IActionResult>  AddRole(RoleModelView model)
         {
            if(ModelState.IsValid)
            {
               IdentityRole role = new IdentityRole{
                Name=model.RoleName
               };
               var result= await _rolemanager.CreateAsync(role);
               if(result.Succeeded)
               {
                return RedirectToAction("Index");
               }
            }
            return View();
         }
        
    }
}