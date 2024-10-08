using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace CRMApp.Components
{
    
    public class UserSummaryViewComponent:ViewComponent
    {
        private readonly IServiceManager _manager;

        public UserSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        

        public String Invoke()
        {
            return _manager.AuthService.GetAllUsers().Count().ToString();
        }






    }




}