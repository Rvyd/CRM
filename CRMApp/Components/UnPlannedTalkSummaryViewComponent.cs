using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Repositories.Contracts; // TalkRepository için gerekli namespace

namespace CRMApp.Components
{
    public class UnPlannedTalkSummaryViewComponent : ViewComponent
    {
        private readonly ITalkRepository _talkRepository;

        public UnPlannedTalkSummaryViewComponent(ITalkRepository talkRepository)
        {
            _talkRepository = talkRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var count = await _talkRepository.GetTalkCountByStatusAsync("Randevu Planlanmadı");
            return Content(count.ToString());
        }
    }

}
