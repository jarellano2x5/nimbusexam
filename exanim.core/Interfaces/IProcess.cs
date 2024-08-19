using exanim.core.DTOs;

namespace exanim.core.Interfaces;

public interface IProcess<T> where T : class
{
    Task<DPage<T>> PageAsync(DateTime date, Guid stage, int size = 15, int page = 0);
}
