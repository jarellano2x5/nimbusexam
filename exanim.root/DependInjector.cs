using System.Text;
using exanim.core.Settings;
using exanim.core.Storages;
using exanim.root.Data;
using exanim.root.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace exanim.root;

public static class DependInjector
{
    public static IServiceCollection AddRoot(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<JwtSetting>(config.GetSection("Jwt"));
        var jwtSec = config.GetSection("Jwt");
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(ops =>
        {
            ops.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSec["Issuer"],
                ValidAudience = jwtSec["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSec["SecretKey"]!)
                ),
                ClockSkew = TimeSpan.Zero
            };
        });

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<AppCtx>(opt =>
        {
            opt.UseSqlServer(config.GetConnectionString("dbnim"));
        });
        
        return services;
    }
}
