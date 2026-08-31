using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;
using exanim.core.Storages;

namespace exanim.core.Services;

public class CFParametroService(IUnitOfWork unitOfWork) : ICFParametroService
{
    private readonly IUnitOfWork _unit = unitOfWork;

    public async Task<int> AddsAsync(Guid? id, IEnumerable<CFParametroDTO> dtos, CancellationToken ct = default)
    {
        try
        {
            int t = dtos.Count();
            if (t == 0) throw new ArgumentException("No records");
            IEnumerable<CFParametroDTO> li = dtos.Where(p => p.Id == null);
            IEnumerable<CFParametroDTO> lu = dtos.Where(p => p.Id != null);
            if (lu.Any())
            {
                Guid[] r = [.. lu.Select(p => p.Id!.Value)];
                int c = await _unit.Parametros.HasAsync(r, ct);
                if (r.Length != c) throw new ArgumentException("Some record not exists");
                foreach (var p in lu)
                    _unit.Parametros.UpdateAsync(p.ToPatch());
            }
            if (li.Any())
            {
                _unit.Parametros.BulkAsync(li.Select(p => p.ToModel()));
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
            int c = await _unit.Parametros.HasAsync(ids, ct);
            ArgumentOutOfRangeException.ThrowIfNotEqual(t, c);
            IEnumerable<CFParametro> ld = await _unit.Parametros
                .SearchAsync(p => ids.Contains(p.Id), ct: ct);
            foreach (CFParametro p in ld)
            {
                p.Activo = false;
                _unit.Parametros.UpdateAsync(p);
            }
            await _unit.CommitAsync(ct);
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<Item>> ItemsAsync(string srch, CancellationToken ct = default)
    {
        try
        {
            IEnumerable<CFParametro> ls = await _unit.Parametros
                .SearchAsync(p => p.Activo == true);
            return ls.Select(p => p.ToItem());
        }
        catch (Exception)
        {
            throw;
        }
    }
}
