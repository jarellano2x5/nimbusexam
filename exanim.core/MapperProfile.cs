using Mapster;
using exanim.core.DTOs;
using exanim.core.Entities;

namespace exanim.core;

public static class MapperProfile
{
    public static void Configure()
    {
        TypeAdapterConfig<Brand, Item>.NewConfig()
            .Map(d => d.Id, s => s.BrandId);
        TypeAdapterConfig<CFAfiliadoDTO, CFUsuario>.NewConfig();
        TypeAdapterConfig<CFAgencia, CFAgenciaDTO>.NewConfig()
            .Map(d => d.Tipo, s => new Option { Id = (byte)s.Tipo, Name = s.Tipo.ToString() })
            .Map(d => d.Plan, s => new Option { Id = (byte)s.Plan, Name = s.Plan.ToString() });
        TypeAdapterConfig<CFAgencia, Item>.NewConfig()
            .Map(d => d.Id, s => s.AgenciaId)
            .Map(d => d.Name, s => s.Nombre)
            .Map(d => d.Code, s => s.RFC);
        TypeAdapterConfig<CFAgenciaDTO, CFAgencia>.NewConfig()
            .Map(d => d.Tipo, s => s.Tipo.Id)
            .Map(d => d.Plan, s => s.Plan.Id);
        TypeAdapterConfig<CFConfigura, Item>.NewConfig()
            .Map(d => d.Id, s => s.ParametroId)
            .Map(d => d.Name, s => s.Cadena)
            .Map(d => d.Code, s => s.Valor.ToString());
        TypeAdapterConfig<CFSignedDTO, CFUsuario>.NewConfig();
        TypeAdapterConfig<CFTaller, Item>.NewConfig()
            .Map(d => d.Id, s => s.TallerId)
            .Map(d => d.Name, s => s.Nombre)
            .Map(d => d.Code, s => s.Codigo);
        TypeAdapterConfig<CFTallerDTO, CFTaller>.NewConfig()
            .Map(d => d.AgenciaId, s => s.Agencia.Id)
            .Map(d => d.UsuarioId, s => s.Usuario.Id);
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
        TypeAdapterConfig<OPClaseDTO, OPClase>.NewConfig()
            .Map(d => d.AgenciaId, s => s.Agencia.Id);
        TypeAdapterConfig<OPClase, Item>.NewConfig()
            .Map(d => d.Id, s => s.ClaseId)
            .Map(d => d.Name, s => s.Nombre);
        TypeAdapterConfig<VEGestor, Item>.NewConfig()
            .Map(d => d.Id, s => s.GestorId);
        TypeAdapterConfig<VEGestorDTO, VEGestor>.NewConfig()
            .Map(d => d.CompaniaId, s => s.Compania.Id);
        TypeAdapterConfig<VEUnidad, Item>.NewConfig()
            .Map(d => d.Id, s => s.UnidadId)
            .Map(d => d.Code, s => s.Placa)
            .Map(d => d.Name, s => $"{s.Modelo} / {s.Anio}");
        TypeAdapterConfig<VEUnidadDTO, VEUnidad>.NewConfig()
            .Map(d => d.MarcaId, s => s.Marca.Id);
    }
}
