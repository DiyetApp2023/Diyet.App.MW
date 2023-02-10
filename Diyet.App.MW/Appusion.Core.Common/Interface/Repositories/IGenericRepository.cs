using Appusion.Core.Common.Base;
using System.Linq.Expressions;

namespace Appusion.Core.Common.Interface.Repositories
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        IQueryable<T> Query();

        Task<T> GetById(int id);

        ICollection<T> GetList(Expression<Func<T, bool>> filter);

        IQueryable<T> Get(Expression<Func<T, bool>> filter);

        Task Insert(T entity);

        Task Insert(IEnumerable<T> entities);

        Task Update(T entity);

        Task Update(IEnumerable<T> entities);

        Task Delete(T entity);

        IQueryable<T> Table { get; }
    }
}