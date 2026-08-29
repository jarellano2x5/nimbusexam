using exanim.core.DTOs;

namespace exanim.core.Interfaces;

public interface ICFLoginService
{
    Task<CFSignedDTO> Register(CFRegisterDTO dto);
    Task<CFSignedDTO> Login(CFLoginDTO dto);
}