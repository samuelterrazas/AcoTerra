using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Trucks;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Trucks.UpdateTruck;

internal sealed class UpdateTruckCommandHandler(
    IApplicationDbContext dbContext
) : ICommandHandler<UpdateTruckCommand> // TODO
{
    public async Task Handle(UpdateTruckCommand request, CancellationToken cancellationToken)
    {
        Truck? truck = await dbContext.EntitySetFor<Truck>()
            .Include(truck => truck.TechnicalInformation)
            .Include(truck => truck.FinancialInformation)
            .Include(truck => truck.Trailer)
            .FirstOrDefaultAsync(truck => truck.Id == request.Id, cancellationToken);

        if (truck is null)
        {
            throw new Exception("The requested resource could not be found.");
        }

        if (request.TechnicalInfo is not null)
        {
            UpdateTechnicalInformation(request.TechnicalInfo, truck);
        }

        if (request.FinancialInfo is not null)
        {
            UpdateFinancialInformation(request.FinancialInfo, truck);
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }
    
    private static void UpdateTechnicalInformation(UpdateTechnicalInformationDto request, Truck truck)
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

    private static void UpdateFinancialInformation(UpdateFinancialInformationDto request, Truck truck)
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
}