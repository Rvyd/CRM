using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Contracts;

namespace CRMApp.Areas.Admin.Controllers
{
  [Area("Admin")]
  [Authorize(Roles = "Admin")]

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

    public IActionResult Delete([FromRoute(Name = "id")] int id)
    {
      _manager.TalkService.DeleteOneTalk(id);
      return RedirectToAction("Index");
    }

    public IActionResult UpdateTalk([FromRoute(Name = "id")] int id)
    {

      var model = _manager.TalkService.GetOneTalkForUpdate(id, false);
      return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateTalk([FromForm] TalkDtoForUpdate talkDto)
    {
      if (ModelState.IsValid)
      {
        _manager.TalkService.UpdateOneTalk(talkDto);
        return RedirectToAction("Index");
      }
      return View(talkDto); 


  }
  }
}