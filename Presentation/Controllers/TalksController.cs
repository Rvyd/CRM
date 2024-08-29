using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;

namespace Presentation.Controllers
{
     [Route("api/talks")]
    [ApiController]

    public class TalksController: ControllerBase
    {
         private readonly IServiceManager _manager;
        public TalksController(IServiceManager manager)
        {
            _manager = manager;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            var result = await _manager.TalkService.GetAllTalks(false);
           return Ok( result.Select(t => new
        {
            title = t.TalkName,
            start = $"{t.StartDate:yyyy-MM-dd}T{t.StartHour}",
            end = $"{t.FinishDate:yyyy-MM-dd}T{t.FinishHour}",
            description = t.Explanation,
            extendedProps = new
            {
                companyId = t.CompanyId,
                companyName = t.CompanyName,
                employee = t.Employee,
                state = t.State
            }
        }).ToList());
           
        }
        }
    }
