using exanim.core.DTOs;

namespace exanim.core.Interfaces;

public interface ICatalog
{
    Task<IEnumerable<Item>> ItemsAsync(string srch);
}
