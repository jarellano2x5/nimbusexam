using Mapster;
using exanim.core.DTOs;
using exanim.core.Entities;
using exanim.core.Enums;

namespace exanim.core;

public static class MapperProfile
{
    public static void Configure()
    {
        TypeAdapterConfig<CFAfiliadoDTO, CFUsuario>.NewConfig();
        TypeAdapterConfig<CFAgencia, CFAgenciaDTO>.NewConfig()
            .Map(d => d.Tipo, s => new Option { Id = (byte)s.Tipo, Name = s.Tipo.ToString() })
            .Map(d => d.Plan, s => new Option { Id = (byte)s.PlanEnum, Name = s.PlanEnum.ToString() });
        TypeAdapterConfig<CFAgencia, Item>.NewConfig()
            .Map(d => d.Id, s => s.AgenciaId)
            .Map(d => d.Name, s => s.Nombre)
            .Map(d => d.Code, s => s.RFC);
        TypeAdapterConfig<CFAgenciaDTO, CFAgencia>.NewConfig()
            .Map(d => d.Tipo, s => s.Tipo.Id)
            .Map(d => d.PlanEnum, s => s.Plan.Id);
        TypeAdapterConfig<CFConfigura, Item>.NewConfig()
            .Map(d => d.Id, s => s.ParametroId)
            .Map(d => d.Name, s => s.Cadena)
            .Map(d => d.Code, s => s.Valor.ToString());
        TypeAdapterConfig<CFSignedDTO, CFUsuario>.NewConfig();
        TypeAdapterConfig<CFUsuarioDTO, CFUsuario>.NewConfig();
        TypeAdapterConfig<CFUsuario, CFUsuarioDTO>.NewConfig();
        TypeAdapterConfig<CFParametro, CFParametroDTO>.NewConfig()
            .Map(d => d.Tipo, s => new Option { Id = (byte)s.Tipo, Name = s.Tipo.ToString() });
        TypeAdapterConfig<CFParametro, Item>.NewConfig()
            .Map(d => d.Id, s => s.ParametroId)
            .Map(d => d.Name, s => s.Clave)
            .Map(d => d.Code, s => s.Tipo.ToString());
        TypeAdapterConfig<CFParametroDTO, CFParametro>.NewConfig()
            .Map(d => d.Tipo, s => s.Tipo.Id);
        TypeAdapterConfig<CFPerfil, CFPerfilDTO>.NewConfig()
            .Map(d => d.Grupo, s => new Option { Id = (byte)s.Grupo, Name = s.Grupo.ToString() });
        TypeAdapterConfig<CFPerfil, Item>.NewConfig()
            .Map(d => d.Id, s => s.PerfilId)
            .Map(d => d.Name, s => s.Nombre);
        TypeAdapterConfig<CFPerfilDTO, CFPerfil>.NewConfig()
            .Map(d => d.Grupo, s => s.Grupo.Id);
    }
}
