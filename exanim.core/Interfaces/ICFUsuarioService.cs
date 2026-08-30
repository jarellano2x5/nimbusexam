using exanim.core.DTOs;

namespace exanim.core.Interfaces;

public interface ICFUsuarioService
{
    Task<CFSocioDTO> AddSocioAsync(CFSocioDTO dto, Guid idAgencia, CancellationToken ct = default);
    Task<IEnumerable<CFSocioDTO>> SociosAsync(Guid idAgencia, CancellationToken ct = default);
    Task<bool> RestSocioAsync(Guid id, CancellationToken ct = default);
}
