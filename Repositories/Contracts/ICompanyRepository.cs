using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICompanyRepository: IRepositoryBase<Company>
    {
        IQueryable<Company> GetAllCompanies(bool trackChange);

        Company? GetOneCompany(int id,bool trackChange);
        
        void CreateCompany(Company company);
        void DeleteOneCompany(Company company);
        void UpdateOneProduct(Company entity);
    }
}