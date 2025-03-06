using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Exceptions;
using AcoTerra.Infrastructure.Data;
using AcoTerra.Infrastructure.Data.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AcoTerra.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Database")
            ?? throw new MissingConfigurationException("Database");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(connectionString)
                .AddInterceptors(new EnableForeignKeyInterceptor())
                .AddInterceptors(new AuditableEntityInterceptor())
                .UseSnakeCaseNamingConvention();

            options.EnableSensitiveDataLogging();
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<DatabaseInitializer>();
    }
}