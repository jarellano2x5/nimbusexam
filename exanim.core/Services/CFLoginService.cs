using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Helpers;
using exanim.core.Interfaces;
using exanim.core.Storages;

namespace exanim.core.Services;

public class CFLoginService(
    IUnitOfWork unitOfWork,
    IHashHelper hash, ITokenHelper help
    ) : ICFLoginService
{
    private readonly IUnitOfWork _unit = unitOfWork;
    public async Task<CFSignedDTO> Register(CFRegisterDTO dto, CancellationToken ct = default)
    {
        try
        {
            CFUsuario? ck = await _unit.Usuarios.GetAsync(u => u.Usuario == dto.Usuario, ct: ct);
            ArgumentNullException.ThrowIfNull(ck, "User already exists");
            CFUsuario mod = dto.ToModel(hash.Create(dto.Password));
            _unit.Usuarios.InsertAsync(mod);
            await _unit.CommitAsync(ct);
            string tk = help.Generar(mod.Usuario, mod.Id.ToString(), null);
            return new CFSignedDTO(mod.Usuario, mod.EsTitular, null, tk);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<CFSignedDTO> Login(CFLoginDTO dto, CancellationToken ct = default)
    {
        try
        {
            CFUsuario? mod = await _unit.Usuarios.GetAsync(u => u.Usuario == dto.Usuario);
            ArgumentNullException.ThrowIfNull(mod, "User not found");
            if (!hash.Compute(dto.Password, mod.Password))
                throw new InvalidDataException("Invalid password");
            CFSocio? soc = await _unit.Socios.GetAsync(s => s.UsuarioId == mod.Id, ct: ct);
            IEnumerable<string>? lr = null;
            if (soc is not null)
            {
                CFPerfil? per = await _unit.Perfiles.GetAsync(p => p.Id == soc.PerfilId, true, ct);
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