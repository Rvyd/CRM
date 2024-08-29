using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly ICompanyRepository _companyRepository;
        private readonly ITalkRepository _talkRepository;

        public RepositoryManager(ICompanyRepository companyRepository, RepositoryContext context, ITalkRepository talkRepository)
        {
            _context = context;
            _companyRepository = companyRepository;
            _talkRepository = talkRepository;
        }

        //Ayrı olarak oluşturduğumuz Company interface'ni yönetme işlemi
        public ICompanyRepository Company => _companyRepository;

        public ITalkRepository Talk => _talkRepository;

        public void Save()
        {
            _context.SaveChanges();
        }


    }
}