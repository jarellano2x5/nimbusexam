using Mapster;
using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Enums;

namespace exanim.core;

public static class MapperProfile
{
    public static void Configure()
    {
        TypeAdapterConfig<CFUsuarioDTO, CFUsuario>.NewConfig();
        TypeAdapterConfig<CFUsuario, CFUsuarioDTO>.NewConfig();
        TypeAdapterConfig<CFPerfil, CFPerfilDTO>.NewConfig()
            .Map(d => d.Grupo, s => new Option { Id = (byte)s.Grupo, Name = s.Grupo.ToString() });
        TypeAdapterConfig<CFPerfil, Item>.NewConfig()
            .Map(d => d.Id, s => s.PerfilId)
            .Map(d => d.Name, s => s.Nombre);
        TypeAdapterConfig<CFPerfilDTO, CFPerfil>.NewConfig()
            .Map(d => d.Grupo, s => s.Grupo.Id);
    }
}
