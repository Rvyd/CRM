using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Repositories.Contracts; // TalkRepository için gerekli namespace

namespace CRMApp.Components
{
    public class TodayScheduledTalksViewComponent : ViewComponent
    {
        private readonly ITalkRepository _talkRepository;

        public TodayScheduledTalksViewComponent(ITalkRepository talkRepository)
        {
            _talkRepository = talkRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Bugünün tarihini DateOnly olarak aldım.
            var today = DateOnly.FromDateTime(DateTime.Today);
            //var tomorrow = today.AddDays(1);

            // Bugünün başlangıç tarihi ile başlayan görüşmeleri getirdim.
            var talks = await _talkRepository.GetTalksByStartDateAsync(today);

            return View(talks); 
        }

    }  
}
