using AcoTerra.API.Common.Abstractions;
using AcoTerra.API.Data;
using AcoTerra.API.Data.Entities.Trucks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.API.Features.Trucks.UpdateTruck;

internal sealed class UpdateTruckEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPut("/{id:guid}", Handle);

    private static async Task<Results<NoContent, NotFound>> Handle(
        Guid id,
        UpdateTruckRequest request,
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken
    )
    {
        Truck? truck = await dbContext.Set<Truck>()
            .Include(truck => truck.TechnicalInformation)
            .Include(truck => truck.FinancialInformation)
            .FirstOrDefaultAsync(truck => truck.Id == id, cancellationToken);

        if (truck is null)
        {
            return TypedResults.NotFound();
        }

        if (request.CurrentMileage.HasValue)
        {
            truck.TechnicalInformation.CurrentMileage = request.CurrentMileage.Value;
        }
        
        if (request.FuelType.HasValue)
        {
            truck.TechnicalInformation.FuelType = request.FuelType.Value;
        }
        
        if (request.AverageConsumption.HasValue)
        {
            truck.TechnicalInformation.AverageConsumption = request.AverageConsumption.Value;
        }
        
        if (request.TankSize.HasValue)
        {
            truck.TechnicalInformation.TankSize = request.TankSize.Value;
        }
        
        if (request.PurchasePrice.HasValue)
        {
            truck.FinancialInformation.PurchasePrice = request.PurchasePrice.Value;
        }
        
        if (request.Financed.HasValue)
        {
            truck.FinancialInformation.Financed = request.Financed.Value;
        }
        
        if (request.Installments.HasValue)
        {
            truck.FinancialInformation.Installments = request.Installments.Value;
        }
        
        if (request.OutstandingBalance.HasValue)
        {
            truck.FinancialInformation.OutstandingBalance = request.OutstandingBalance.Value;
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        return TypedResults.NoContent();
    }
}