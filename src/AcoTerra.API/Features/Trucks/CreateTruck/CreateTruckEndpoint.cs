using AcoTerra.API.Common.Abstractions;
using AcoTerra.API.Data.Entities.Trucks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.API.Features.Trucks.CreateTruck;

internal sealed class CreateTruckEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPost("/", Handle);

    private static async Task<Results<Created<int>, BadRequest>> Handle(
        CreateTruckRequest request,
        IApplicationDbContext dbContext,
        CancellationToken cancellationToken
    )
    {
        bool isTrailerRegistered = await dbContext
            .EntitySetFor<Trailer>()
            .AsNoTracking()
            .AnyAsync(trailer => trailer.LicensePlate == request.Trailer.LicensePlate, cancellationToken);

        if (isTrailerRegistered)
        {
            return TypedResults.BadRequest();
        }
        
        var truck = new Truck
        {
            LicensePlate = request.LicensePlate,
            Brand = request.Brand,
            Model = request.Model,
            ManufacturingYear = request.ManufacturingYear,
            ChassisNumber = request.ChassisNumber,
            EngineNumber = request.EngineNumber,
            Trailer = new Trailer
            {
                LicensePlate = request.Trailer.LicensePlate,
                Capacity = request.Trailer.Capacity,
            },
        };

        dbContext.EntitySetFor<Truck>().Add(truck);
        
        await dbContext.SaveChangesAsync(cancellationToken);

        return TypedResults.Created($"trucks/{truck.Id}", truck.Id);
    }
}