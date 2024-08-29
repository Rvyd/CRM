using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly ICompanyService _companyService;
        private readonly IAuthService _authService;
        private readonly ITalkService _talkService;

        public ServiceManager(ICompanyService companyService, IAuthService authService, ITalkService talkService)
        {
            _companyService = companyService;
            _authService = authService;
            _talkService = talkService;
        }

        public ICompanyService CompanyService => _companyService;

        public IAuthService AuthService => _authService;

        public ITalkService TalkService =>_talkService;
    }
}