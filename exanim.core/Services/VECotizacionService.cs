using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;
using exanim.core.Storages;

namespace exanim.core.Services;

public class VECotizacionService(IUnitOfWork unitOfWork) : IVECotizacionService
{
    private readonly IUnitOfWork _unit = unitOfWork;

    public async Task<VECotizacionDTO> AddAsync(AuthMe me, VECotizacionDTO dto, CancellationToken ct = default)
    {
        try
        {
            VECotizacion mod = dto.ToModel(me.IdAgen!.Value);
            mod.Monto = dto.Lineas.Sum(l => l.Cantidad * l.Precio);
            await EvolAdd(dto.Lineas, mod.Id);
            await _unit.CommitAsync(ct);
            return dto with { Id = mod.Id };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> DownAsync(Guid id, CancellationToken ct = default)
    {
        try
        {
            VECotizacion? mod = await _unit.Cotizaciones.GetAsync(id, ct);
            mod.Activo = false;
            _unit.Cotizaciones.UpdateAsync(mod);
            await _unit.CommitAsync(ct);
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<VECotizacionDTO> FixAsync(AuthMe me, Guid id, VECotizacionDTO dto, CancellationToken ct = default)
    {
        try
        {
            VECotizacion? mod = await _unit.Cotizaciones.GetAsync(c => c.Id == id, true, ct);
            ArgumentNullException.ThrowIfNull(mod);
            _unit.Cotizaciones.UpdateAsync(mod.ToExists(dto));
            await EvolAdd(dto.Lineas.Where(l => l.Id == null), id);
            Guid[] idds = [.. dto.Lineas.Select(l => l.Id!.Value)];
            IEnumerable<VELinea> ld = await _unit.Lineas
                .SearchAsync(l => l.CotizacionId == id && !idds.Contains(l.Id),
                    ct: ct);
            foreach (var l in ld)
                _unit.Lineas.DeleteAsync(l);
            ld = await _unit.Lineas
                .SearchAsync(l => l.CotizacionId == id && idds.Contains(l.Id), ct: ct);
            foreach (var l in ld)
            {
                VELineaDTO d = dto.Lineas.First(lm => lm.Id == l.Id);
                _unit.Lineas.UpdateAsync(l.ToExists(d));
            }
            await _unit.CommitAsync(ct);
            return dto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<DPage<VECotizacionMinDTO>> PageAsync(AuthMe me, DateTime date, Guid stage, int size = 15, int page = 0, CancellationToken ct = default)
    {
        try
        {
            int cnt = await _unit.Cotizaciones.HasAsync(c =>
                c.AgenciaId == stage && c.Fecha.Year == date.Year && c.Fecha.Month == date.Month, ct);
            IEnumerable<VECotizacion> ls = await _unit.Cotizaciones .StageAsync(c =>
                c.AgenciaId == stage && c.Fecha.Year == date.Year &&
                c.Fecha.Month == date.Month, page * size, size, true, ct);
            DPage<VECotizacionMinDTO> dto = new()
            {
                Count = cnt, Pages = (int)Math.Ceiling(cnt / (decimal)size),
                Limit = size, Records = ls.Select(c => c.ToMin())
            };
            return dto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<VECotizacionDTO> PickAsync(Guid id, CancellationToken ct = default)
    {
        try
        {
            VECotizacion? mod = await _unit.Cotizaciones.GetAsync(c => c.Id == id, true, ct);
            ArgumentNullException.ThrowIfNull(mod, "record not found");
            VECotizacionDTO dto = mod.ToDto();
            if (dto.Orden is not null)
            {
                OPOrden? ord = await _unit.Ordenes.GetAsync(dto.Orden.Id, ct);
                if (ord != null)
                    dto.Orden = new Item(ord.Id, ord.Problema);
            }
            if (dto.Cliente is not null)
            {
                VECliente? cli = await _unit.Clientes.GetAsync(c => c.Id == dto.Cliente.Id, true, ct);
                if (cli != null)
                    dto.Cliente = new Item(cli.Id, cli.Usuario.Nombre);
            }
            return dto;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private Task EvolAdd(IEnumerable<VELineaDTO> li, Guid id)
    {
        foreach (var l in li)
            _unit.Lineas.InsertAsync(l.ToModel(id));
        return Task.CompletedTask;
    }
}
