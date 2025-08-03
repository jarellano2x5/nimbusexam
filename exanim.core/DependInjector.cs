using Microsoft.Extensions.DependencyInjection;
using exanim.core.Interfaces;
using exanim.core.Services;
using Mapster;

namespace exanim.core;

public static class DependInjector
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICFPerfilService, CFPerfilService>();
        services.AddScoped<ICFUsuarioService, CFUsuarioService>();
        services.AddScoped<IUtilService, UtilService>();
        services.AddMapster();
        MapperProfile.Configure();

        return services;
    }
}
