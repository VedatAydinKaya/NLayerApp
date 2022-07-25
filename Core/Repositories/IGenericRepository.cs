using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IGenericRepository<T> where T : class   // Product,Category,ProductFeature
    {
        Task<T> GetByIdAsync(int id);

        // productRepository.GetAll(x=>x.Id>5).OrderBy.ToListAsync();
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);


        // productRepository.Where(x=>x.Id>5).OrderBy.ToListAsync(); *** 
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);

        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

 

        

    }
}
