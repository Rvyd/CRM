using System.Linq.Expressions;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T> //generic yapıda olduğunu belirttim
    {
        IQueryable<T> FindAll(bool trackChanges); //listeleme işlemi,izlenilebilir formatta
        T? FinByCondition(Expression<Func<T,bool>> expression,bool trackChange);//tek bir firma bulmak istediğimiz zaman
        void Create(T Entity);

        void Remove(T entity);

        void Update(T entity);

        void SubmitCompany(T entity);

     
   
    }
}