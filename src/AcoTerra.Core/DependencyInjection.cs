using AcoTerra.Core.Common.Behaviors;
using AcoTerra.Core.Features.Agents;
using AcoTerra.Core.Features.Trailers;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AcoTerra.Core;

public static class DependencyInjection
{
    public static void AddCore(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly, includeInternalTypes: true);

        services.AddScoped<AgentService>();
        services.AddScoped<TrailerService>();
    }
}