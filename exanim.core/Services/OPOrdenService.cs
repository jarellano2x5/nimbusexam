using System.Globalization;
using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;
using exanim.core.Storages;

namespace exanim.core.Services;

public class OPOrdenService(IUnitOfWork unitOfWork) : IOPOrdenService
{
    private readonly IUnitOfWork _unit = unitOfWork;

    public async Task<OPOrdenDTO> AddAsync(Guid idUsuario, OPOrdenDTO dto, CancellationToken ct = default)
    {
        try
        {

            if (dto.Nueva is not null)
            {
                VEUnidad mun = dto.Nueva.ToModel();
                _unit.Unidades.InsertAsync(mun);
                dto.Unidad = new(mun.Id, mun.Placa);
            }
            OPOrden mod = dto.ToModel(idUsuario);
            _unit.Ordenes.InsertAsync(mod);
            await _unit.CommitAsync(ct);
            return dto with { Id = mod.Id };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<OPOrdenMinDTO>> GetAllAsync(Guid idTaller, string criterio, int semana, CancellationToken ct = default)
    {
        try
        {
            IEnumerable<OPOrden> li = await _unit.Ordenes
                .SearchAsync(o => o.TallerId == idTaller
                && (semana == 0 || ISOWeek.GetWeekOfYear(o.FechaEntrega == null ? o.Fecha : o.FechaEntrega!.Value.ToDateTime(new TimeOnly())) == semana)
                && (o.Problema.Contains(criterio) || o.Unidad.Placa.Contains(criterio)), false, true, ct);
            return li.Select(o => o.ToMin());
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<OPOrdenDTO> GetAsync(Guid id, CancellationToken ct = default)
    {
        try
        {
            OPOrden? mod = await _unit.Ordenes.GetAsync(id, ct);
            ArgumentNullException.ThrowIfNull(mod, "record not found");
            VECliente? cli = await _unit.Clientes
                .GetAsync(c => c.Id == mod.ClienteId, true, ct);
            CFTaller? tal = await _unit.Talleres.GetAsync(mod.TallerId, ct);
            return mod.ToDto() with
            {
                Cliente = new(cli!.Id, cli!.Usuario.Nombre),
                Taller = new(tal!.Id, tal!.Nombre, tal!.Codigo)
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
}
