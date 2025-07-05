using System.Linq.Expressions;

namespace TestAPI.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllSync();
        Task<IEnumerable<T>> GetBy(Expression<Func<T, bool>> predicate);
        Task<T?> GetByIdAsync(int id);
        Task AddSync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
