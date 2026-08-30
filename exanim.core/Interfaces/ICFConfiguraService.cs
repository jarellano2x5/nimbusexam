using exanim.core.DTOs;

namespace exanim.core.Interfaces;

public interface ICFConfiguraService : IChunk<CFConfiguraDTO>
{
    Task<IEnumerable<Item>> ItemsAsync(Guid idAgencia, CancellationToken ct = default);
}
