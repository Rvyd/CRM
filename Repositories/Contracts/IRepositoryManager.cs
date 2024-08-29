namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        ICompanyRepository Company{get;}

        ITalkRepository Talk{get;}

        void Save(); //IF core nesneleri izler ve değişikleri fark edip kayıt eder.
      
    }

   
}