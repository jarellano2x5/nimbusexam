using exanim.core.DTOs;

namespace exanim.core.Interfaces;

public interface ICatalog
{
    Task<IEnumerable<Item>> ItemsAsync(AuthMe me, string srch, CancellationToken ct = default);
}
