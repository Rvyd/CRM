using Microsoft.AspNetCore.Mvc;

namespace CRMApp.Controllers
{
    public class CalenderController : Controller

    {
        public IActionResult Index()
        {
            return View();
        }
    }
}