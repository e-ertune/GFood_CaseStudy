using GFood_CaseStudy.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GFood_CaseStudy.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Added;
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public bool Any(Expression<Func<TEntity, bool>> filter, string[]? includes = null)
        {
            using (var context = new TContext())
            {
                var result = context.Set<TEntity>().AsQueryable();
                for (int i = 0; i < includes?.Length; i++)
                {
                    result = result.Include(includes[i]);
                }
                return result.Any();
            }
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter, string[]? includes = null)
        {
            using (var context = new TContext())
            {
                var result = context.Set<TEntity>().AsQueryable();
                for (int i = 0; i < includes?.Length; i++)
                {
                    result = result.Include(includes[i]);
                }
                return await result.AnyAsync();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, string[]? includes = null)
        {
            using (var context = new TContext())
            {
                var result = context.Set<TEntity>().AsQueryable();
                for (int i = 0; i < includes?.Length; i++)
                {
                    result = result.Include(includes[i]);
                }
                return result.SingleOrDefault(filter);
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, string[]? includes = null)
        {
            using (var context = new TContext())
            {
                var result = context.Set<TEntity>().AsQueryable();
                for (int i = 0; i < includes?.Length; i++)
                {
                    result = result.Include(includes[i]);
                }
                return await result.SingleOrDefaultAsync(filter);
            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>>? filter = null, string[]? includes = null)
        {
            using (var context = new TContext())
            {
                var result = filter == null ? context.Set<TEntity>().AsQueryable() : context.Set<TEntity>().Where(filter).AsQueryable();
                for (int i = 0; i < includes?.Length; i++)
                {
                    result = result.Include(includes[i]);
                }
                return result.ToList();
            }
        }

        public async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? filter = null, string[]? includes = null)
        {
            using (var context = new TContext())
            {
                var result = filter == null ? context.Set<TEntity>().AsQueryable() : context.Set<TEntity>().Where(filter).AsQueryable();
                for (int i = 0; i < includes?.Length; i++)
                {
                    result = result.Include(includes[i]);
                }
                return await result.ToListAsync();
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Added;
                await context.SaveChangesAsync();
                return entity;
            }
        }
    }
}
