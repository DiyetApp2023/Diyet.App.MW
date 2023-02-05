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

        public TEntity GetById(int id)
        {
            return DbContext.Find<TEntity>(id);
        }

        public ICollection<TEntity> GetList(Expression<Func<TEntity, bool>> filter)
        {
            return DbContext.Set<TEntity>().Where(filter).ToList();
        }

        public void Insert(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            DbContext.SaveChanges();
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().AddRange(entities);
            DbContext.SaveChanges();
        }

        public IQueryable<TEntity> Query()
        {
            return DbContext.Set<TEntity>().AsQueryable();
        }

        public void Update(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                DbContext.Entry(entity).State = EntityState.Modified;
            }
            DbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
        }
    }
}