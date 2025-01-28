using AcoTerra.API.Common.Abstractions;
using AcoTerra.API.Data;
using AcoTerra.API.Data.Entities.Trucks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.API.Features.Trucks.GetTruckDetails;

internal sealed class GetTruckDetailsEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapGet("/{id:guid}", Handle);
    
    private static async Task<Results<Ok<TruckDetailsResponse>, NotFound>> Handle(
        Guid id,
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken
    )
    {
        Truck? truck = await dbContext
            .Set<Truck>()
            .AsNoTracking()
            .Include(truck => truck.TechnicalInformation)
            .Include(truck => truck.FinancialInformation)
            .FirstOrDefaultAsync(truck => truck.Id == id, cancellationToken);

        if (truck is null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok((TruckDetailsResponse)truck);
    }
}