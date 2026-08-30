using Microsoft.Extensions.DependencyInjection;
using exanim.core.Interfaces;
using exanim.core.Services;

namespace exanim.core;

public static class DependInjector
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<ICFAgenciaService, CFAgenciaService>();
        services.AddScoped<ICFConfiguraService, CFConfiguraService>();
        services.AddScoped<ICFParametroService, CFParametroService>();
        services.AddScoped<ICFPerfilService, CFPerfilService>();
        services.AddScoped<ICFTallerService, CFTallerService>();
        services.AddScoped<ICFUsuarioService, CFUsuarioService>();
        services.AddScoped<IUtilService, UtilService>();
        services.AddScoped<IVEClienteService, VEClienteService>();
        services.AddScoped<IVEUnidadService, VEUnidadService>();

        return services;
    }
}
