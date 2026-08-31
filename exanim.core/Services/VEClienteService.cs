using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;
using exanim.core.Storages;

namespace exanim.core.Services;

public class VEClienteService(IUnitOfWork unitOfWork) : IVEClienteService
{
    private readonly IUnitOfWork _unit = unitOfWork;

    public async Task<VEClienteDTO> AddAsync(AuthMe me, VEClienteDTO dto, CancellationToken ct = default)
    {
        try
        {
            VECliente mod = dto.ToModel();
            _unit.Clientes.InsertAsync(mod);
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
            VECliente? mod = await _unit.Clientes.GetAsync(id, ct);
            ArgumentNullException.ThrowIfNull(mod, "record not found");
            mod.Activo = false;
            _unit.Clientes.UpdateAsync(mod);
            await _unit.CommitAsync(ct);
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<VEClienteDTO> FixAsync(AuthMe me, Guid id, VEClienteDTO dto, CancellationToken ct = default)
    {
        try
        {
            VECliente? mod = await _unit.Clientes.GetAsync(id, ct);
            ArgumentNullException.ThrowIfNull(mod, "record not found");
            _unit.Clientes.UpdateAsync(mod.ToExists(dto));
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
            IEnumerable<VECliente> ls = await _unit.Clientes
                .SearchAsync(c => c.Activo == true, ct: ct);
            return ls.Select(c => c.ToItem());
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<VEClienteDTO> PickAsync(Guid id, CancellationToken ct = default)
    {
        try
        {
            VECliente? mod = await _unit.Clientes.GetAsync(id, ct);
            ArgumentNullException.ThrowIfNull(mod, "record not found");
            return mod.ToDto();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
