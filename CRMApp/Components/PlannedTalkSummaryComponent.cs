using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Repositories.Contracts; // TalkRepository için gerekli namespace

namespace CRMApp.Components
{
    public class PlannedTalkSummaryViewComponent : ViewComponent
    {
        private readonly ITalkRepository _talkRepository;

        public PlannedTalkSummaryViewComponent(ITalkRepository talkRepository)
        {
            _talkRepository = talkRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var count = await _talkRepository.GetTalkCountByStatusAsync("Randevu Alındı");
            return Content(count.ToString());
        }
    }

}
