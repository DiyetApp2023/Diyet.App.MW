using Appusion.Core.Common.Entities.Misyon;
using Misyon.Core.Common.Entities.Misyon;
using System.Linq.Expressions;

namespace Appusion.Core.Common.Interface.Repositories
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        IQueryable<T> Query();

        T GetById(int id);

        ICollection<T> GetList(Expression<Func<T, bool>> filter);

        IQueryable<T> Get(Expression<Func<T, bool>> filter);

        void Insert(T entity);

        void Insert(IEnumerable<T> entities);

        void Update(T entity);

        void Update(IEnumerable<T> entities);

        void Delete(T entity);

        IQueryable<T> Table { get; }
    }
}