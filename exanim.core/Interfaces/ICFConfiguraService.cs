using exanim.core.DTOs;

namespace exanim.core.Interfaces;

public interface ICFConfiguraService : IBulk<CFConfiguraDTO>
{
    Task<IEnumerable<Item>> ItemsAsync(Guid idAgencia, CancellationToken ct = default);
}
