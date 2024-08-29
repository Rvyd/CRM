using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace CRMApp.Areas.Admin.Controllers
{
     [Area("Admin")]
     [Authorize(Roles ="Admin")]
    public class CompanyController : Controller
    {
        private readonly IServiceManager _manager;

        public CompanyController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.CompanyService.GetAllCompanies(false);
            return View(model);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //formun doğrulanması için
        public async Task<IActionResult> Create([FromForm] CompanyDtoForInsertion companyDto,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                 //file operation
                 string path=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images",file.FileName);
                 using (var stream=new FileStream(path,FileMode.Create))
                 {
                     await file.CopyToAsync(stream);
                 }
                 companyDto.CompanyLogoUrl=String.Concat("images/",file.FileName);
                _manager.CompanyService.CreateCompany(companyDto);

                return RedirectToAction("Index"); //firmayı ekleyip index sayfasına yönlendirir

            }
            return View();
        }


        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            var model = _manager.CompanyService.GetOneCompanyForUpdate(id, false);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm]CompanyDtoForUpdate companyDto,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //file operation
                 string path=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images",file.FileName);
                 using (var stream=new FileStream(path,FileMode.Create))
                 {
                     await file.CopyToAsync(stream);
                 }
                 companyDto.CompanyLogoUrl=String.Concat("images/",file.FileName);
               

                _manager.CompanyService.UpdateOneProduct(companyDto);
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            
              _manager.CompanyService.DeleteOneCompany(id);
              return RedirectToAction("Index");
        }



    }
    
}