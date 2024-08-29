using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    //temel sınıfların new'lenmesini istemediğimiz için abstract yaptım
    //Base sınıfı devralanlar ilgili sınıflar kendileri dolduracak
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    where T : class, new() //tipi kısıtladım.
    {
        //DIR çerçevesi 
        protected readonly RepositoryContext _context;

        protected RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity); //ürün ekleme işlemini yaptık
        }


        public T? FinByCondition(Expression<Func<T, bool>> expression, bool trackChange)
        {
            return trackChange
             ? _context.Set<T>().Where(expression).SingleOrDefault()
             : _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges
             ? _context.Set<T>()
             : _context.Set<T>().AsNoTracking();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void SubmitCompany(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}