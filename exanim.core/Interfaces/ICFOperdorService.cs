using exanim.core.DTOs;

namespace exanim.core.Interfaces;

public interface ICFOperdorService : ISegment
{
    Task<IEnumerable<CFOperadorDTO>> GetAllAsync(Guid idAgen, string srch, CancellationToken ct = default);
}