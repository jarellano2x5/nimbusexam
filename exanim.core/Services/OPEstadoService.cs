using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;
using exanim.core.Storages;

namespace exanim.core.Services;

public class OPEstadoService(IUnitOfWork unitOfWork) : IOPEstadoService
{
    private readonly IUnitOfWork _unit = unitOfWork;

    public async Task<int> AddsAsync(Guid? id, IEnumerable<OPEstadoDTO> dtos, CancellationToken ct = default)
    {
        try
        {
            IEnumerable<OPEstadoDTO> li = dtos.Where(e => e.Id == null);
            IEnumerable<OPEstadoDTO> lu = dtos.Where(e => e.Id != null);
            if (lu.Any())
            {
                Guid[] r = [.. lu.Select(e => e.Id!.Value)];
                int ee = await _unit.Estados.HasAsync(r, ct);
                ArgumentOutOfRangeException.ThrowIfNotEqual(r.Length, ee);
                IEnumerable<OPEstado> ls = await _unit.Estados
                    .SearchAsync(e => r.Contains(e.Id), ct: ct);
                IEnumerable<OPEstado> le = ls.Join(lu, m => m.Id, d => d.Id,
                    (m, d) => m.ToExists(d, id!.Value));
                foreach (OPEstado e in le)
                    _unit.Estados.UpdateAsync(e);
            }
            if (li.Any())
            {
                foreach (OPEstadoDTO e in li)
                    _unit.Estados.InsertAsync(e.ToModel(id!.Value));
            }
            await _unit.CommitAsync(ct);
            return dtos.Count();
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
            int c = await _unit.Estados.HasAsync(ids, ct);
            ArgumentOutOfRangeException.ThrowIfNotEqual(ids.Length, c);
            IEnumerable<OPEstado> le = await _unit.Estados
                .SearchAsync(e => ids.Contains(e.Id), ct: ct);
            foreach (OPEstado e in le)
            {
                e.Activo = false;
                _unit.Estados.UpdateAsync(e);
            }
            await _unit.CommitAsync(ct);
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<Item>> ItemsAsync(Guid id, string srch, CancellationToken ct = default)
    {
        try
        {
            IEnumerable<OPEstado> ls = await _unit.Estados
                .SearchAsync(e => e.AgenciaId == id && e.Activo == true, ct: ct);
            return ls.Select(e => e.ToItem());
        }
        catch (Exception)
        {
            throw;
        }
    }
}
