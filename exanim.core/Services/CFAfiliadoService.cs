using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Interfaces;
using MapsterMapper;

namespace exanim.core.Services;

public class CFAfiliadoService(
    IRepository<CFUsuario> repository, IMapper mapper,
    IRepository<CFPerfil> perfilRepo
) : ICFAfiliadoService
{
    private readonly IRepository<CFUsuario> _repo = repository;
    private readonly IRepository<CFPerfil> _perfil = perfilRepo;
    private readonly IMapper _map = mapper;

    public async Task<CFSignedDTO> LoginAsync(CFLoginDTO dto)
    {
        try
        {
            CFUsuario? mod = await _repo.GetAsync(u => u.Usuario == dto.Usuario && u.Password == u.Password);
            if (mod is null) throw new Exception("Record not found");
            if (!mod.Activo) throw new Exception("Record was disabled");
            CFPerfil? per = await _perfil.GetAsync(p => p.PerfilId == mod.PerfilId);
            CFSignedDTO rec = _map.Map<CFSignedDTO>(mod);
            return rec with { Grupo = per!.Grupo };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CFSignedDTO> RegisterAsync(CFAfiliadoDTO dto)
    {
        try
        {
            IEnumerable<CFUsuario> ls = await _repo.SearchAsync(u => u.Usuario == dto.Usuario || u.Correo == dto.Correo);
            if (ls.Any()) throw new Exception("Email or user already exists");
            CFUsuario mod = _map.Map<CFUsuario>(dto);
            mod.UsuarioId = Guid.NewGuid();
            CFPerfil? per = await _perfil.GetAsync(p => p.Grupo == Enums.CFGrupoEnum.Usuario);
            if (per is null) throw new Exception("Profiles not found");
            mod.PerfilId = per.PerfilId;
            mod.Activo = true;
            await _repo.InsertAsync(mod);
            CFSignedDTO rec = _map.Map<CFSignedDTO>(mod);
            return rec with { Grupo = per.Grupo };
        }
        catch (Exception)
        {
            throw;
        }
    }
}
