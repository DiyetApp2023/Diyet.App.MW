using Microsoft.EntityFrameworkCore;
using Appusion.Core.Common.Implementation.DbContexts;
using Appusion.Core.Common.Interface.Repositories;

using System.Linq.Expressions;
using Appusion.Core.Common.Base;

namespace Appusion.Core.Common.Implementation.Repositories
{
    public abstract class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
                                                        where TEntity : EntityBase
                                                        where TContext : AppusionDbContext
    {

        protected readonly TContext DbContext;
        public GenericRepository(TContext context)
        {
            DbContext = context;
        }
        public IQueryable<TEntity> Table => DbContext.Set<TEntity>();


        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return DbContext.Set<TEntity>().AsQueryable().Where(filter);
        }

        public async Task<TEntity> GetById(int id)
        {
            return await DbContext.FindAsync<TEntity>(id);
        }

        public ICollection<TEntity> GetList(Expression<Func<TEntity, bool>> filter)
        {
            return DbContext.Set<TEntity>().Where(filter).ToList();
        }

        public async Task Insert(TEntity entity)
        {
            await DbContext.Set<TEntity>().AddAsync(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task Insert(IEnumerable<TEntity> entities)
        {
            await DbContext.Set<TEntity>().AddRangeAsync(entities);
            await DbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> Query()
        {
            return DbContext.Set<TEntity>().AsQueryable();
        }

        public async Task Update(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        public async Task Update(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                DbContext.Entry(entity).State = EntityState.Modified;
            }
            await DbContext.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}