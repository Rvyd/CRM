using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Repositories.Contracts; // TalkRepository için gerekli namespace

namespace CRMApp.Components
{
    public class DoneTalkSummaryViewComponent : ViewComponent
    {
        private readonly ITalkRepository _talkRepository;

        public DoneTalkSummaryViewComponent(ITalkRepository talkRepository)
        {
            _talkRepository = talkRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var count = await _talkRepository.GetTalkCountByStatusAsync("Tamamlandı");
            return Content(count.ToString());
        }
    }

}
