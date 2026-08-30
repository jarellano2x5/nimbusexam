using exanim.core.Storages;
using exanim.root.Data;
using exanim.root.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace exanim.root;

public static class DependInjector
{
    public static IServiceCollection AddRoot(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<AppCtx>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("dbnim"));
        });
        
        return services;
    }
}
