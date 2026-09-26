using System.Linq.Expressions;
using exanim.core.Entities;

namespace exanim.core.Storages;

public interface IRepository<T> where T : Entity
{
    void InsertAsync(T model);
    void BulkAsync(IEnumerable<T> models); 
    void UpdateAsync(T model);
    void DeleteAsync(T model);
    Task<int> HasAsync(Expression<Func<T, bool>> query, CancellationToken ct = default);
    Task<T?> GetAsync(Guid id, CancellationToken ct = default);
    Task<T?> GetAsync(Expression<Func<T, bool>> query, bool include = false,
        CancellationToken ct = default);
    Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> query,
        bool tracking = false, bool addIncludes = false, CancellationToken ct = default);
    Task<IEnumerable<T>> StageAsync(Expression<Func<T, bool>> query,
        int skip = 0, int take = 20, bool addIncludes = false, CancellationToken ct = default);
}
