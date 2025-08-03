using System.Linq.Expressions;
using exanim.core.Entities;
using exanim.core.Interfaces;
using exanim.root.Data;
using Microsoft.EntityFrameworkCore;

namespace exanim.root.Repositories;

public class RepositoryAlt<T>(AppCtx context) : IRepositoryAlt<T> where T : EntityAlt
{
    private readonly AppCtx _ctx = context;

    public async Task DeleteAsync(T model)
    {
        _ctx.Set<T>().Remove(model);
        await _ctx.SaveChangesAsync();
    }

    public async Task<T?> GetAsync(Guid id, Guid idt)
    {
        return await _ctx.Set<T>().FindAsync([id, idt]);
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> query)
    {
        return await Mount().Where(query).FirstOrDefaultAsync();
    }

    public async Task InsertAsync(T model)
    {
        _ctx.Set<T>().Add(model);
        await _ctx.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> query, bool tracking = false, bool addIncludes = false)
    {
        return await Mount().Where(query).ToListAsync();
    }

    public async Task UpdateAsync(T model)
    {
        _ctx.Set<T>().Update(model);
        await _ctx.SaveChangesAsync();
    }

    private DbSet<T> Mount()
    {
        DbSet<T> entity = _ctx.Set<T>();
        entity.AsNoTracking();
        entity.IgnoreAutoIncludes();
        return entity;
    }
}
