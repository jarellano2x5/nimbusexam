using exanim.core.DTOs;

namespace exanim.core.Interfaces;

public interface ICFLoginService
{
    Task<CFSignedDTO> Register(CFRegisterDTO dto, CancellationToken ct = default);
    Task<CFSignedDTO> Login(CFLoginDTO dto, CancellationToken ct = default);
}