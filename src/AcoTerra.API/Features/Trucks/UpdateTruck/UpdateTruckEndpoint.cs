using AcoTerra.API.Common.Abstractions;
using AcoTerra.API.Data;
using AcoTerra.API.Data.Entities.Trucks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.API.Features.Trucks.UpdateTruck;

internal sealed class UpdateTruckEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPut("/{id:int}", Handle);

    private static async Task<Results<NoContent, NotFound>> Handle(
        int id,
        UpdateTruckRequest request,
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

        if (request.TechnicalInfo is not null)
        {
            UpdateTechnicalInformation(request.TechnicalInfo, truck);
        }

        if (request.FinancialInfo is not null)
        {
            UpdateFinancialInformation(request.FinancialInfo, truck);
        }

        if (request.Trailer is not null)
        {
            UpdateTrailer(request.Trailer, truck);
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        return TypedResults.NoContent();
    }

    private static void UpdateTechnicalInformation(UpdateTechnicalInformationRequest request, Truck truck)
    {
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
    }

    private static void UpdateFinancialInformation(UpdateFinancialInformationRequest request, Truck truck)
    {
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
    }

    private static void UpdateTrailer(UpdateTrailerRequest request, Truck truck)
    {
        if (truck.Trailer is null)
        {
            throw new NullReferenceException();
        }
        
        if (request.LicensePlate is not null)
        {
            truck.Trailer.LicensePlate = request.LicensePlate;
        }

        if (request.Capacity.HasValue)
        {
            truck.Trailer.Capacity = request.Capacity.Value;
        }
    }
}