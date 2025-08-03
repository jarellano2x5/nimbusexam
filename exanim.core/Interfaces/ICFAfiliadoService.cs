using exanim.core.DTOs;

namespace exanim.core.Interfaces;

public interface ICFAfiliadoService
{
    Task<CFSignedDTO> RegisterAsync(CFAfiliadoDTO dto);
    Task<CFSignedDTO> LoginAsync(CFLoginDTO dto);
}
