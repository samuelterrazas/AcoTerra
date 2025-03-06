using AcoTerra.API.Common.Abstractions;
using AcoTerra.API.Data.Entities.Producers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.API.Features.Producers.SearchProducers;

internal sealed class SearchProducersEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapGet("/", Handle);

    private static async Task<Ok<List<ProducerResponse>>> Handle(
        IApplicationDbContext dbContext,
        CancellationToken cancellationToken
    )
    {
        List<ProducerResponse> producers = await dbContext
            .EntitySetFor<Producer>()
            .Select(producer => (ProducerResponse)producer)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        
        
        return TypedResults.Ok(producers);
    }
}