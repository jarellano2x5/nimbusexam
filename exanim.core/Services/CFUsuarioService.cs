using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;
using exanim.core.Storages;

namespace exanim.core.Services;

public class CFUsuarioService(IUnitOfWork unitOfWork) : ICFUsuarioService
{
    private readonly IUnitOfWork _unit = unitOfWork;
    
    public async Task<CFSocioDTO> AddSocioAsync(CFSocioDTO dto, Guid idAgencia, CancellationToken ct = default)
    {
        try
        {
            CFUsuario? u = await _unit.Usuarios
                .GetAsync(u => u.Correo == dto.Correo
                    || u.Usuario == dto.Usuario, false, ct);
            if (u is not null) throw new ArgumentNullException(nameof(u.Correo), "record already exists");
            CFUsuario mus = dto.ToUser();
            _unit.Usuarios.InsertAsync(mus);
            CFSocio mod = dto.ToModel(mus.Id, idAgencia);
            _unit.Socios.InsertAsync(mod);
            await _unit.CommitAsync(ct);
            return dto with { Id = mod.Id };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IEnumerable<CFSocioDTO>> SociosAsync(Guid idAgencia, CancellationToken ct = default)
    {
        try
        {
            IEnumerable<CFSocio> ls = await _unit.Socios
                .SearchAsync(s => s.AgenciaId == idAgencia, false, true, ct: ct);
            return ls.Select(s => s.ToDto());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> RestSocioAsync(Guid id, CancellationToken ct = default)
    {
        try
        {
            CFSocio? mod = await _unit.Socios.GetAsync(id, ct);
            ArgumentNullException.ThrowIfNull(mod, "record not found");
            _unit.Socios.DeleteAsync(mod);
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
