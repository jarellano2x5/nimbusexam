using exanim.core.DTOs;

namespace exanim.core.Interfaces;

public interface IBreak<T> where T : class
{
    Task<DPage<T>> PageAsync(AuthMe me, DateTime date, Guid stage, int size = 15, int page = 0, CancellationToken ct = default);
}
