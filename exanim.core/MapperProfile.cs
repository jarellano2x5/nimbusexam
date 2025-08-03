using AutoMapper;
using exanim.core.DTOs;
using exanim.core.Entities;

namespace exanim.core;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<CFUsuarioDTO, CFUsuario>();
        CreateMap<CFUsuario, CFUsuarioDTO>();
    }
}
