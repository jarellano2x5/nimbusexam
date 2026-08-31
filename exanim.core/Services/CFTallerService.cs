using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;
using exanim.core.Storages;

namespace exanim.core.Services;

public class CFTallerService(IUnitOfWork unitOfWork) : ICFTallerService
{
    private readonly IUnitOfWork _unit = unitOfWork;

    public async Task<int> AddsAsync(AuthMe me, IEnumerable<CFTallerDTO> dtos, CancellationToken ct = default)
    {
        int t = dtos.Count();
        ArgumentOutOfRangeException.ThrowIfZero(t, "no records");
        IEnumerable<CFTallerDTO> li = dtos.Where(t => t.Id == null);
        IEnumerable<CFTallerDTO> lu = dtos.Where(t => t.Id != null);
        if (lu.Any())
        {
            Guid[] r = [.. lu.Select(t => t.Id!.Value)];
            int c = await _unit.Talleres.HasAsync(r, ct);
            ArgumentOutOfRangeException.ThrowIfNotEqual(r.Length, c);
            foreach (var ta in lu)
                _unit.Talleres.UpdateAsync(ta.ToPatch(me.IdAgen!.Value));
        }
        if (li.Any())
        {
            _unit.Talleres.BulkAsync(li.Select(t => t.ToModel(me.IdAgen!.Value)));
        }
        await _unit.CommitAsync(ct);
        return t;
    }

    public async Task<bool> DownsAsync(Guid[] ids, CancellationToken ct = default)
    {
        try
        {
            int c = await _unit.Talleres.HasAsync(ids, ct);
            ArgumentOutOfRangeException.ThrowIfNotEqual(ids.Length, c);
            IEnumerable<CFTaller> lt = await _unit.Talleres
                .SearchAsync(t => ids.Contains(t.Id), ct: ct);
            foreach (CFTaller t in lt)
            {
                t.Activo = false;
                _unit.Talleres.UpdateAsync(t);
            }
            await _unit.CommitAsync(ct);
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<Item>> ItemsAsync(AuthMe me, string srch, CancellationToken ct = default)
    {
        try
        {
            IEnumerable<CFTaller> ls = await _unit.Talleres
                .SearchAsync(t => t.AgenciaId == me.IdAgen && t.Activo == true, ct: ct);
            return ls.Select(t => t.ToItem());
        }
        catch (Exception)
        {
            throw;
        }
    }
}
