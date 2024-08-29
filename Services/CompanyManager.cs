using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
namespace Services
{
    public class CompanyManager : ICompanyService
    {
        //Bir alt katmandaki nesneyi buraya ekliyoruz.
        private readonly IRepositoryManager _manager;

        private readonly IMapper _mapper;

        public CompanyManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateCompany(CompanyDtoForInsertion companyDto)
        {
            Company company=_mapper.Map<Company>(companyDto);
            _manager.Company.Create(company);
            _manager.Save();
        }

        public void DeleteOneCompany(int id)
        {
            Company company = GetOneCompany(id, false);
            if (company is not null)
            {
                _manager.Company.DeleteOneCompany(company);
                _manager.Save();
            }

        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges)
        {
            return _manager.Company.GetAllCompanies(trackChanges);
        }

        public Company? GetOneCompany(int id, bool trackChanges)
        {
            var company = _manager.Company.GetOneCompany(id, trackChanges);
            if (company is null)
                throw new Exception($"Company with ID {id} not found."); ;

            return company;
        }

        public CompanyDtoForUpdate GetOneCompanyForUpdate(int id, bool trackChanges)
        {
           var company=GetOneCompany(id,trackChanges);
           var companyDto=_mapper.Map<CompanyDtoForUpdate>(company);
           return companyDto;
        }

        public void UpdateOneProduct(CompanyDtoForUpdate companyDto)
        {
             var entity=_mapper.Map<Company>(companyDto);
            _manager.Company.UpdateOneProduct(entity);
            _manager.Save();

        }
    }
}
