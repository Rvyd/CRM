using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;

namespace CRMApp.Components
{
    public class CompanySummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public CompanySummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        //Müşteri sayısını hesaplamak için
        public string Invoke()
        {
            
           return _manager.CompanyService.GetAllCompanies(false).Count().ToString();        }
    }
}