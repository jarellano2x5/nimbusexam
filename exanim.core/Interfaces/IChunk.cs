using exanim.core.Entities;

namespace exanim.core.Interfaces;

public interface IChunk<T> where T : class
{
    Task<int> AddsAsync(IEnumerable<T> dtos, CancellationToken ct = default);
    Task<bool> DownsAsync(Guid[] ids, CancellationToken ct = default);
}