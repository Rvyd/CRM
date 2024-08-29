using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Services.Contracts;



namespace CRMApp.Controllers
{
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

    
        public IActionResult CreateTalk(int id)
        {
            var company = _manager.CompanyService.GetOneCompany(id, false);

            var talkDto = new TalkDtoForInsertion
            {
                CompanyId = company.CompanyId,
                CompanyName = company.CompanyName,
                CompanyLogoUrl = company.CompanyLogoUrl,
            };

            return View(talkDto);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTalk(TalkDtoForInsertion talkDto)
        {
            if (ModelState.IsValid)
            {
                
                _manager.TalkService.CreateTalk(talkDto);

                
                return RedirectToAction("Index");
            }

            // ModelState geçerli değilse, View'e modeli tekrar gönderir
            return View(talkDto);
        }



    }
}