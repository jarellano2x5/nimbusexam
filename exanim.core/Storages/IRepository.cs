using System.Linq.Expressions;
using exanim.core.Entities;

namespace exanim.core.Storages;

public interface IRepository<T> where T : Entity
{
    void InsertAsync(T model);
    void AddsAsync(IEnumerable<T> models); 
    void UpdateAsync(T model);
    void AttachAsync(IEnumerable<T> models);
    void DeleteAsync(T model);
    Task<int> HasAsync(Guid[] ids, CancellationToken ct = default);
    Task<T?> GetAsync(Guid id, CancellationToken ct = default);
    Task<T?> GetAsync(Expression<Func<T, bool>> query, bool include = false,
        CancellationToken ct = default);
    Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> query,
        bool tracking = false, bool addIncludes = false,
        CancellationToken ct = default);
}
