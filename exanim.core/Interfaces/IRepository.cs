using System.Linq.Expressions;
using exanim.core.Entities;

namespace exanim.core.Interfaces;

public interface IRepository<T> where T : Entity
{
    Task InsertAsync(T model);
    Task DeleteAsync(T model);
    Task<T?> GetAsync(Guid id);
    Task<T?> GetAsync(Expression<Func<T, bool>> query);
    Task UpdateAsync(T model);
    Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> query, bool tracking = false, bool addIncludes = false);
}
