using System.Linq.Expressions;
using exanim.core.Entities;
using exanim.core.Interfaces;
using exanim.root.Data;
using Microsoft.EntityFrameworkCore;

namespace exanim.root.Repositories;

public class Repository<T> : IRepository<T> where T : Entity
{
    private readonly AppCtx _ctx;

    public Repository(AppCtx context)
    {
        _ctx = context;
    }

    public async Task DeleteAsync(T model)
    {
        _ctx.Set<T>().Remove(model);
        await _ctx.SaveChangesAsync();
    }

    public async Task<T?> GetAsync(Guid id)
    {
        return await _ctx.Set<T>().FindAsync(id);
    }

    public async Task InsertAsync(T model)
    {
        _ctx.Set<T>().Add(model);
        await _ctx.SaveChangesAsync();
    }

    public Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> query, bool tracking = false, bool addIncludes = false)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(T model)
    {
        _ctx.Set<T>().Update(model);
        await _ctx.SaveChangesAsync();
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
