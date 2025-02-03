using AcoTerra.API.Common.Abstractions;
using AcoTerra.API.Data.Entities.Freights;
using AcoTerra.API.Data.Entities.Trucks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.API.Features.Freights.GetFreightDetails;

internal sealed class GetFreightDetailsEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapGet("/{id:int}", Handle);

    private static async Task<Results<Ok<FreightDetailsResponse>, NotFound>> Handle(
        int id,
        IApplicationDbContext dbContext,
        CancellationToken cancellationToken
    )
    {
        Freight? freight = await dbContext
            .EntitySetFor<Freight>()
            .Include(freight => ((Truck)freight.Vehicle).Trailer)
            .Include(freight => freight.Employee)
            .Include(freight => freight.Shipments)
            .ThenInclude(shipment => shipment.Producer)
            .Include(freight => freight.Shipments)
            .ThenInclude(shipment => shipment.Product)
            .Include(freight => freight.Shipments)
            .ThenInclude(shipment => shipment.Customer)
            .AsNoTracking()
            .AsSplitQuery()
            .FirstOrDefaultAsync(freight => freight.Id == id, cancellationToken);

        if (freight is null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok((FreightDetailsResponse)freight);
    }
}