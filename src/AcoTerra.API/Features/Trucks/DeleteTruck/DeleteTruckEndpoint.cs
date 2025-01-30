using AcoTerra.API.Common.Abstractions;
using AcoTerra.API.Data;
using AcoTerra.API.Data.Entities.Trucks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.API.Features.Trucks.DeleteTruck;

internal sealed class DeleteTruckEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapDelete("/{id:int}", Handle);

    private static async Task<Results<NoContent, NotFound>> Handle(
        int id,
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken
    )
    {
        Truck? truck = await dbContext.Set<Truck>()
            .Include(truck => truck.TechnicalInformation)
            .Include(truck => truck.FinancialInformation)
            .Include(truck => truck.Trailer)
            .FirstOrDefaultAsync(truck => truck.Id == id, cancellationToken);

        if (truck is null)
        {
            return TypedResults.NotFound();
        }

        dbContext.Set<Truck>().Remove(truck);

        await dbContext.SaveChangesAsync(cancellationToken);

        return TypedResults.NoContent();
    }
}