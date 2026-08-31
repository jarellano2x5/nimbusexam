using exanim.core.DTOs;

namespace exanim.core.Interfaces;

public interface IBulk<T> where T : class
{
    Task<int> AddsAsync(AuthMe me, IEnumerable<T> dtos, CancellationToken ct = default);
    Task<bool> DownsAsync(Guid[] ids, CancellationToken ct = default);
}