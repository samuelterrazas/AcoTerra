using AcoTerra.API.Common.Abstractions;
using AcoTerra.API.Data;
using AcoTerra.API.Data.Entities.Trucks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.API.Features.Trucks.SearchTrucks;

internal sealed class SearchTrucksEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapGet("/", Handle);
    
    private static async Task<Ok<List<TruckResponse>>> Handle(
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken
    )
    {
        List<TruckResponse> trucks = await dbContext
            .Set<Truck>()
            .AsNoTracking()
            .Select(truck => (TruckResponse)truck)
            .ToListAsync(cancellationToken);

        return TypedResults.Ok(trucks);
    }
}