using exanim.core.DTOs;
using exanim.core.Enums;
using exanim.core.Interfaces;
using MapsterMapper;

namespace exanim.core.Services;

public class UtilService(IMapper mapper) : IUtilService
{
    private readonly IMapper _map = mapper;

    public IEnumerable<Option> GetPerfil()
    {
        IEnumerable<Option> ls = Enum.GetValues(typeof(CFGrupoEnum))
            .Cast<CFGrupoEnum>()
            .Select(e => new Option
            {
                Id = (byte)e,
                Name = e.ToString()
            });
        return ls;
    }
}
