using AcoTerra.API.Common.Abstractions;
using AcoTerra.API.Data;
using AcoTerra.API.Data.Entities.Trucks;
using AcoTerra.API.Data.Entities.Vehicles;
using AcoTerra.API.Data.Entities.Vehicles.Enums;
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
            TechnicalInformation = new TechnicalInformation
            {
                CurrentMileage = request.CurrentMileage ?? 0,
                FuelType = request.FuelType ?? FuelType.None,
                AverageConsumption = request.AverageConsumption ?? 0,
                TankSize = request.TankSize ?? 0,
            },
            FinancialInformation = new FinancialInformation
            {
                PurchasePrice = request.PurchasePrice ?? 0,
                Financed = request.Financed ?? false,
                Installments = request.Installments ?? 0,
                OutstandingBalance = request.OutstandingBalance ?? 0,
            },
        };

        dbContext.Set<Truck>().Add(truck);
        
        await dbContext.SaveChangesAsync(cancellationToken);

        return TypedResults.Created($"trucks/{truck.Id}", truck.Id);
    }
}