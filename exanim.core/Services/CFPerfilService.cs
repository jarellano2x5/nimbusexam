using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Enums;
using exanim.core.Interfaces;
using exanim.core.Storages;

namespace exanim.core.Services;

public class CFPerfilService(IUnitOfWork unitOfWork) : ICFPerfilService
{
    private readonly IUnitOfWork _unit = unitOfWork;

    public async Task<CFPerfilDTO> AddAsync(AuthMe me, CFPerfilDTO dto, CancellationToken ct = default)
    {
        try
        {
            CFPerfil mod = dto.ToModel();
            mod.Roles = [.. dto.Rols.Select(r => r.ToModel(mod.Id))];
            _unit.Perfiles.InsertAsync(mod);
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
            CFPerfil? mod = await _unit.Perfiles.GetAsync(id, ct);
            ArgumentNullException.ThrowIfNull(mod, nameof(mod));
            mod.Activo = false;
            _unit.Perfiles.UpdateAsync(mod);
            await _unit.CommitAsync(ct);
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CFPerfilDTO> FixAsync(AuthMe me, Guid id, CFPerfilDTO dto, CancellationToken ct = default)
    {
        try
        {
            CFPerfil? mod = await _unit.Perfiles.GetAsync(p => p.Id == id, true, ct);
            ArgumentNullException.ThrowIfNull(mod, "not found");
            await EvalRol(mod.Roles.Select(r => r.Rol), dto.Rols.Select(r => (RolEnum)r.Id), id, ct);
            _unit.Perfiles.UpdateAsync(mod.ToExists(dto));
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
            IEnumerable<CFPerfil> ls = await _unit.Perfiles
                .SearchAsync(p => p.AgenciaId == me.IdAgen && p.Activo == true, ct: ct);
            return ls.Select(p => p.ToItem());
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CFPerfilDTO> PickAsync(Guid id, CancellationToken ct = default)
    {
        try
        {
            CFPerfil? mod = await _unit.Perfiles.GetAsync(p => p.Id == id, true, ct);
            ArgumentNullException.ThrowIfNull(mod, nameof(mod));
            return mod.ToDto();
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task EvalRol(IEnumerable<RolEnum> le, IEnumerable<RolEnum> lc, Guid id, CancellationToken ct)
    {
        RolEnum[] ld = [.. le.Except(lc)];
        if (ld.Length > 0)
        {
            IEnumerable<CFRol> lm = await _unit.Roles
                .SearchAsync(r => r.PerfilId == id && ld.Contains(r.Rol), ct: ct);
            foreach (CFRol r in lm)
                _unit.Roles.DeleteAsync(r);
        }
        ld = [.. lc.Except(le)];
        if (ld.Length > 0)
        {
            IEnumerable<CFRol> li = ld.Select(e => new CFRol { Id = Guid.NewGuid(), Rol = e, PerfilId = id });
            foreach (CFRol r in li)
                _unit.Roles.InsertAsync(r);
        }
    }
}
