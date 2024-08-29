using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        //context ifademizi base sınıfımıza göndermek ve veritabanını erişmek için
        public CompanyRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateCompany(Company company)=>Create(company);

        public void DeleteOneCompany(Company company)=>Remove(company);
        

        //Base de bulunan metodu baz olarak metodumuzun kullanımı
        public IQueryable<Company> GetAllCompanies(bool trackChange)=>FindAll(trackChange);
       
       public Company? GetOneCompany(int id,bool trackChange)
       {
         return FinByCondition(p=>p.CompanyId.Equals(id),trackChange);
       }

        public void UpdateOneProduct(Company entity)=>Update(entity);
    }
}