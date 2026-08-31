using exanim.core.DTOs;

namespace exanim.core.Interfaces;

public interface ISegment
{
    Task<IEnumerable<Item>> ItemsAsync(Guid idAgen, string srch, CancellationToken ct = default);
}
