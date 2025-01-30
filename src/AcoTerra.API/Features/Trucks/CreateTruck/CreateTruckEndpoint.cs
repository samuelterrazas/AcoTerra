using AcoTerra.API.Common.Abstractions;
using AcoTerra.API.Data;
using AcoTerra.API.Data.Entities.Trucks;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AcoTerra.API.Features.Trucks.CreateTruck;

internal sealed class CreateTruckEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPost("/", Handle);

    private static async Task<Created<int>> Handle(
        CreateTruckRequest request,
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken
    )
    {
        var truck = new Truck
        {
            LicensePlate = request.LicensePlate,
            Brand = request.Brand,
            Model = request.Model,
            ManufacturingYear = request.ManufacturingYear,
            ChassisNumber = request.ChassisNumber,
            EngineNumber = request.EngineNumber,
            Trailer = request.Trailer is not null
                ? new Trailer
                {
                    LicensePlate = request.Trailer.LicensePlate,
                    Capacity = request.Trailer.Capacity,
                }
                : null,
        };

        dbContext.Set<Truck>().Add(truck);

        await dbContext.SaveChangesAsync(cancellationToken);

        return TypedResults.Created($"trucks/{truck.Id}", truck.Id);
    }
}