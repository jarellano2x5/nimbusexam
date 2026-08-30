using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;
using exanim.core.Storages;

namespace exanim.core.Services;

public class CFConfiguraService(IUnitOfWork unitOfWork) : ICFConfiguraService
{
    private readonly IUnitOfWork _unit = unitOfWork;

    public async Task<int> AddsAsync(Guid? id, IEnumerable<CFConfiguraDTO> dtos, CancellationToken ct = default)
    {
        try
        {
            int t = dtos.Count();
            ArgumentOutOfRangeException.ThrowIfZero(t);
            IEnumerable<CFConfiguraDTO> li = dtos.Where(c => c.Id == null);
            IEnumerable<CFConfiguraDTO> lu = dtos.Where(c => c.Id != null);
            if (lu.Any())
            {
                Guid[] r = lu.Select(c => c.Id!.Value).ToArray();
                int e = await _unit.Configuras.HasAsync(r, ct);
                ArgumentOutOfRangeException.ThrowIfNotEqual(r.Length, e);
                IEnumerable<CFConfigura> ls = await _unit.Configuras
                    .SearchAsync(c => r.Contains(c.Id), ct: ct);
                IEnumerable<CFConfigura> lf = ls.Join(lu, m => m.Id, d => d.Id, (m, d) => m.ToExists(d));
                foreach (CFConfigura c in lf)
                    _unit.Configuras.UpdateAsync(c);
            }
            if (li.Any())
            {
                foreach (CFConfiguraDTO d in li)
                    _unit.Configuras.InsertAsync(d.ToModel());
            }
            await _unit.CommitAsync(ct);
            return t;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> DownsAsync(Guid[] ids, CancellationToken ct = default)
    {
        try
        {
            int t = ids.Length;
            ArgumentOutOfRangeException.ThrowIfZero(t);
            int c = await _unit.Configuras.HasAsync(ids, ct);
            ArgumentOutOfRangeException.ThrowIfNotEqual(t, c);
            IEnumerable<CFConfigura> lc = await _unit.Configuras
                .SearchAsync(c => ids.Contains(c.Id), ct: ct);
            foreach (CFConfigura co in lc)
            {
                co.Activo = false;
                _unit.Configuras.UpdateAsync(co);
            }
            await _unit.CommitAsync(ct);
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<Item>> ItemsAsync(Guid idAgencia, CancellationToken ct = default)
    {
        try
        {
            IEnumerable<CFConfigura> ls = await _unit.Configuras
                .SearchAsync(c => c.Activo == true, ct: ct);
            return ls.Select(c => c.ToItem());
        }
        catch (Exception)
        {
            throw;
        }
    }
}
