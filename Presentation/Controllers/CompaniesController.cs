using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController:ControllerBase
    {
        private readonly IServiceManager _manager;

        public CompaniesController(IServiceManager manager)
        {
            _manager=manager;
        }

        [HttpGet]
        public IActionResult GetAllCompanies()
        {
             return Ok(_manager.CompanyService.GetAllCompanies(false));
        }
    }
}

