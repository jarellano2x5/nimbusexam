using exanim.core.DTOs;

namespace exanim.core.Interfaces;

public interface ICFConfiguraService : IService<CFConfiguraDTO>
{
    Task<IEnumerable<Item>> ItemsAsync(Guid idAgencia);
}
