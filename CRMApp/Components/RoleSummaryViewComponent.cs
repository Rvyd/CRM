using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace CRMApp.Components
{
    public class RoleSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public RoleSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }


        public String Invoke()
        {
            return _manager.AuthService.Roles.Count().ToString();
        }
    }
}