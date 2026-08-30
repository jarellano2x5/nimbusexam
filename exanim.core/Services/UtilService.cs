using exanim.core.DTOs;
using exanim.core.Enums;
using exanim.core.Interfaces;

namespace exanim.core.Services;

public class UtilService : IUtilService
{
    public IEnumerable<Option> GetRol()
    {
        IEnumerable<Option> ls = Enum.GetValues(typeof(RolEnum))
            .Cast<RolEnum>()
            .Select(e =>
                new Option((byte)e, e.ToString()));
        return ls;
    }
}
