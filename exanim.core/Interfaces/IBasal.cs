using exanim.core.DTOs;

namespace exanim.core.Interfaces;

public interface IBasal<T> where T : class
{
    Task<T> AddAsync(AuthMe me, T dto, CancellationToken ct = default);
    Task<T> FixAsync(AuthMe me, Guid id, T dto, CancellationToken ct = default);
    Task<bool> DownAsync(Guid id, CancellationToken ct = default);
    Task<T> PickAsync(Guid id, CancellationToken ct = default);
}
