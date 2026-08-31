using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;
using exanim.core.Storages;

namespace exanim.core.Services;

public class VEUnidadService(IUnitOfWork unitOfWork) : IVEUnidadService
{
    private readonly IUnitOfWork _unit = unitOfWork;

    public async Task<VEUnidadDTO> AddAsync(AuthMe me, VEUnidadDTO dto, CancellationToken ct = default)
    {
        try
        {
            VEUnidad mod = dto.ToModel();
            _unit.Unidades.InsertAsync(mod);
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
            VEUnidad? mod = await _unit.Unidades.GetAsync(id, ct);
            ArgumentNullException.ThrowIfNull(mod, "record not found");
            mod.Activo = false;
            _unit.Unidades.UpdateAsync(mod);
            await _unit.CommitAsync(ct);
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<VEUnidadDTO> FixAsync(AuthMe me, Guid id, VEUnidadDTO dto, CancellationToken ct = default)
    {
        try
        {
            VEUnidad? mod = await _unit.Unidades.GetAsync(id, ct);
            ArgumentNullException.ThrowIfNull(mod, "record not found");
            _unit.Unidades.UpdateAsync(mod.ToExists(dto));
            await _unit.CommitAsync(ct);
            return dto;
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
            IEnumerable<VEUnidad> ls = await _unit.Unidades
                .SearchAsync(u => u.Activo == true, ct: ct);
            return ls.Select(u => u.ToItem());
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<VEUnidadDTO> PickAsync(Guid id, CancellationToken ct = default)
    {
        try
        {
            VEUnidad? mod = await _unit.Unidades.GetAsync(id, ct);
            ArgumentNullException.ThrowIfNull(mod, "record not found");
            return mod.ToDto();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
