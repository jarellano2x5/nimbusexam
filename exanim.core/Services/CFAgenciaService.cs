using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;
using exanim.core.Storages;

namespace exanim.core.Services;

public class CFAgenciaService(IUnitOfWork unitOfWork) : ICFAgenciaService
{
    private readonly IUnitOfWork _unit = unitOfWork;

    public async Task<CFAgenciaDTO> AddAsync(AuthMe me, CFAgenciaDTO dto, CancellationToken ct = default)
    {
        try
        {
            CFAgencia mod = dto.ToModel();
            _unit.Agencias.InsertAsync(mod);
            await _unit.CommitAsync(ct);
            return dto with { Id = mod.Id };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CFAgenciaDTO> FixAsync(AuthMe me, Guid id, CFAgenciaDTO dto, CancellationToken ct = default)
    {
        try
        {
            CFAgencia? mod = await _unit.Agencias.GetAsync(id, ct);
            ArgumentNullException.ThrowIfNull(mod);
            _unit.Agencias.UpdateAsync(mod.ToExists(dto));
            await _unit.CommitAsync(ct);
            return dto;
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
            CFAgencia? mod = await _unit.Agencias.GetAsync(id, ct);
            ArgumentNullException.ThrowIfNull(mod);
            mod.Activo = false;
            _unit.Agencias.UpdateAsync(mod);
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
            IEnumerable<CFAgencia> ls = await _unit.Agencias.SearchAsync(a => a.Nombre.Contains(srch), ct: ct);
            return ls.Select(a => a.ToItem());
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CFAgenciaDTO> PickAsync(Guid id, CancellationToken ct = default)
    {
        try
        {
            CFAgencia? mod = await _unit.Agencias.GetAsync(id, ct);
            ArgumentNullException.ThrowIfNull(mod);
            return mod.ToDto();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
