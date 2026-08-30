namespace exanim.core.Interfaces;

public interface IService<T> where T : class
{
    Task<T> AddAsync(T dto, CancellationToken ct = default);
    Task<T> FixAsync(Guid id, T dto, CancellationToken ct = default);
    Task<bool> DownAsync(Guid id, CancellationToken ct = default);
    Task<T> PickAsync(Guid id, CancellationToken ct = default);
}
