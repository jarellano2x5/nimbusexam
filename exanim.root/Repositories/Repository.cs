using System.Linq.Expressions;
using exanim.core.Entities;
using exanim.core.Storages;
using exanim.root.Data;
using Microsoft.EntityFrameworkCore;

namespace exanim.root.Repositories;

public class Repository<T>(AppCtx context) : IRepository<T> where T : Entity
{
    private readonly AppCtx _ctx = context;

    public void DeleteAsync(T model)
    {
        _ctx.Set<T>().Remove(model);
    }

    public Task<int> HasAsync(Guid[] ids, CancellationToken ct = default)
    {
        return _ctx.Set<T>().Where(e => ids.Contains(e.Id)).CountAsync(ct);
    }

    public async Task<T?> GetAsync(Guid id, CancellationToken ct = default)
    {
        return await _ctx.Set<T>().FindAsync(id, ct);
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> query, bool include = false, CancellationToken ct = default)
    {
        return await Mount(false, include).Where(query).FirstOrDefaultAsync(ct);
    }

    public void InsertAsync(T model)
    {
        _ctx.Set<T>().Add(model);
    }

    public void BulkAsync(IEnumerable<T> models)
    {
        _ctx.Set<T>().AddRange(models);
    }

    public async Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> query,
        bool tracking = false, bool addIncludes = false, CancellationToken cancellationToken = default)
    {
        return await Mount(tracking, addIncludes).Where(query)
            .ToListAsync(cancellationToken);
    }

    public void UpdateAsync(T model)
    {
        _ctx.Set<T>().Update(model);
    }

    private DbSet<T> Mount(bool tracking, bool include)
    {
        DbSet<T> entity = _ctx.Set<T>();
        if (!tracking)
        {
            entity.AsNoTracking();
        }
        if (!include)
        {
            entity.IgnoreAutoIncludes();
        }
        return entity;
    }
}
