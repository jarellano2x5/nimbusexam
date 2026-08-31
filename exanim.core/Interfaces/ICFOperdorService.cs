using exanim.core.DTOs;

namespace exanim.core.Interfaces;

public interface ICFOperdorService : ICatalog
{
    Task<IEnumerable<CFOperadorDTO>> GetAllAsync(Guid idAgen, string srch, CancellationToken ct = default);
}