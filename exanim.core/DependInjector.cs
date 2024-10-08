using Microsoft.Extensions.DependencyInjection;
using exanim.core.Interfaces;
using exanim.core.Services;

namespace exanim.core;

public static class DependInjector
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddAutoMapper(typeof(MapperProfile));

        return services;
    }
}
