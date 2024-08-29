using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Services.Contracts;

namespace CRMApp.Controllers
{

    public class TalkController : Controller
    {
        private readonly IServiceManager _manager;

        public TalkController(IServiceManager manager)
        {
            _manager = manager;
        }
        // LINQ kullanımı
        public async Task<IActionResult> Index()
        {

            var Talks = await _manager.TalkService.GetAllTalks(false);

            var groupedTalks = Talks
                               .GroupBy(t => t.CompanyId)
                               .OrderBy(g => g.Key)
                                .ToList();
            return View(groupedTalks);
        }



    }
}