using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Helpers;
using exanim.core.Interfaces;
using Mapster;

namespace exanim.core.Services;

public class CFLoginService(IRepository<CFUsuario> repo,
    IRepository<CFSocio> repSoc,
    IRepository<CFPerfil> repPer,
    IHashHelper hash, ITokenHelper help
    ) : ICFLoginService
{
    public async Task<CFSignedDTO> Register(CFRegisterDTO dto)
    {
        try
        {
            CFUsuario? ck = await repo.GetAsync(u => u.Usuario == dto.Usuario);
            if (ck != null)
                throw new InvalidDataException("User already exists");
            CFUsuario mod = dto.Adapt<CFUsuario>();
            mod.Id = Guid.NewGuid();
            mod.Activo = true;
            mod.EsTitular = true;
            await repo.InsertAsync(mod);
            string tk = help.Generar(mod.Usuario, mod.Id.ToString(), null);
            return new CFSignedDTO(mod.Usuario, mod.EsTitular, null, tk);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<CFSignedDTO> Login(CFLoginDTO dto)
    {
        try
        {
            CFUsuario? mod = await repo.GetAsync(u => u.Usuario == dto.Usuario);
            ArgumentNullException.ThrowIfNull(mod);
            if (!hash.Compute(dto.Password, mod.Password))
                throw new InvalidDataException("Invalid password");
            CFSocio? soc = await repSoc.GetAsync(s => s.UsuarioId == mod.Id);
            IEnumerable<string>? lr = null;
            if (soc is not null)
            {
                CFPerfil? per = await repPer.GetAsync(p => p.Id == soc.PerfilId, true);
                lr = per?.Roles.Select(r => r.Rol.ToString());
            }
            string tk = help.Generar(mod.Usuario, mod.Id.ToString(), lr);
            return new CFSignedDTO(mod.Usuario, mod.EsTitular, soc?.AgenciaId, tk);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}