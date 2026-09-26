using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Enums;
using exanim.core.Interfaces;
using exanim.core.Storages;

namespace exanim.core.Services;

public class OPEstadoService(IUnitOfWork unitOfWork) : IOPEstadoService
{
    private readonly IUnitOfWork _unit = unitOfWork;

    public async Task<int> AddsAsync(AuthMe me, IEnumerable<OPEstadoDTO> dtos, CancellationToken ct = default)
    {
        try
        {
            IEnumerable<OPEstadoDTO> li = dtos.Where(e => e.Id == null);
            IEnumerable<OPEstadoDTO> lu = dtos.Where(e => e.Id != null);
            if (lu.Any())
            {
                Guid[] r = [.. lu.Select(e => e.Id!.Value)];
                int ee = await _unit.Estados.HasAsync(e => r.Contains(e.Id), ct);
                ArgumentOutOfRangeException.ThrowIfNotEqual(r.Length, ee);
                IEnumerable<OPEstado> ls = await _unit.Estados
                    .SearchAsync(e => r.Contains(e.Id), ct: ct);
                IEnumerable<OPEstado> le = ls.Join(lu, m => m.Id, d => d.Id,
                    (m, d) => m.ToExists(d, me.IdAgen!.Value));
                foreach (OPEstado e in le)
                    _unit.Estados.UpdateAsync(e);
            }
            if (li.Any())
            {
                foreach (OPEstadoDTO e in li)
                    _unit.Estados.InsertAsync(e.ToModel(me.IdAgen!.Value));
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
            int c = await _unit.Estados.HasAsync(e => ids.Contains(e.Id), ct);
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

    public async Task<IEnumerable<Item>> ItemsAsync(AuthMe me, string srch, CancellationToken ct = default)
    {
        try
        {
            IEnumerable<OPEstado> ls = await _unit.Estados
                .SearchAsync(e => e.AgenciaId == me.IdAgen && e.Activo == true, ct: ct);
            return ls.Select(e => e.ToItem());
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> Configure(AuthMe me, CancellationToken ct = default)
    {
        try
        {
            int qn = await _unit.Estados.HasAsync(e => e.AgenciaId == me.IdAgen!.Value, ct);
            if (qn > 0) return false;
            IEnumerable<OPEstado> li =
            [
                new()
                {
                    Id = Guid.NewGuid(), Nombre = "Generada",
                    Fase = OPFaseEnum.Inicio, Code = "GEN01",
                    AgenciaId = me.IdAgen!.Value
                },
                new()
                {
                    Id = Guid.NewGuid(), Nombre = "En proceso",
                    Fase = OPFaseEnum.Trabajando, Code = "EPR01",
                    AgenciaId = me.IdAgen!.Value
                },
                new()
                {
                    Id = Guid.NewGuid(), Nombre = "Por aprobar",
                    Fase = OPFaseEnum.Pausa, Code = "PAU01",
                    AgenciaId = me.IdAgen!.Value
                },
                new()
                {
                    Id = Guid.NewGuid(), Nombre = "Terminado",
                    Fase = OPFaseEnum.Completo, Code = "TER01",
                    AgenciaId = me.IdAgen!.Value
                },
                new()
                {
                    Id = Guid.NewGuid(), Nombre = "Cancelado",
                    Fase = OPFaseEnum.Cese, Code = "CAN01",
                    AgenciaId = me.IdAgen!.Value
                }
            ];
            foreach (OPEstado e in li)
                _unit.Estados.InsertAsync(e);
            await _unit.CommitAsync(ct);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
