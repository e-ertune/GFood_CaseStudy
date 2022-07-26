using GFood_CaseStudy.Core.Entities;
using System.Linq.Expressions;

namespace GFood_CaseStudy.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        bool Any(Expression<Func<T, bool>> filter, string[]? includes = null);
        T Get(Expression<Func<T, bool>> filter, string[]? includes = null);
        IList<T> GetList(Expression<Func<T, bool>>? filter = null, string[]? includes = null);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);

        Task<bool> AnyAsync(Expression<Func<T, bool>> filter, string[]? includes = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, string[]? includes = null);
        Task<IList<T>> GetListAsync(Expression<Func<T, bool>>? filter = null, string[]? includes = null);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
