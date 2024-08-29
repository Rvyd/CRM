using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetAllCompanies(bool trackChanges);
        Company? GetOneCompany(int id,bool trackChanges);

        void CreateCompany(CompanyDtoForInsertion company);
        void UpdateOneProduct(CompanyDtoForUpdate company);
        void DeleteOneCompany(int id);
        CompanyDtoForUpdate GetOneCompanyForUpdate(int id, bool trackChanges);
    }
}