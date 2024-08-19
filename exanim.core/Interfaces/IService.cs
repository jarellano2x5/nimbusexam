namespace exanim.core.Interfaces;

public interface IService<T> where T : class
{
    Task<T> AddAsync(T dto);
    Task<T> AttachAsync(Guid id, T dto);
    Task<bool> DownAsync(Guid id);
    Task<T> PickAsync(Guid id);
}
