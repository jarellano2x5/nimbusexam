using exanim.core.Interfaces;
using exanim.root.Data;
using exanim.root.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace exanim.root;

public static class DependInjector
{
    public static IServiceCollection AddRoot(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddDbContext<AppCtx>(opt =>
        {
            
        });
        
        return services;
    }
}
