using exanim.core.DTOs;

namespace exanim.core.Interfaces;

public interface ICFUsuarioService : IService<CFUsuarioDTO>
{
    Task<IEnumerable<CFUsuarioDTO>> AllAsync();
}
