using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Common.Exceptions;
using AcoTerra.Core.Entities.Agents;
using AcoTerra.Core.Entities.Trucks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Trucks.UpdateTruck;

public sealed record UpdateTruckCommand(
    int Id,
    TechnicalInformationUpdateDto? TechnicalInformation,
    FinancialInformationUpdateDto? FinancialInformation,
    int? TrailerId,
    int? DriverId
) : ICommand<Unit>;


internal sealed class UpdateTruckCommandHandler(
    IApplicationDbContext dbContext
) : ICommandHandler<UpdateTruckCommand, Unit> // TODO
{
    public async Task<Unit> Handle(UpdateTruckCommand request, CancellationToken cancellationToken)
    {
        Truck? truck = await dbContext.EntitySetFor<Truck>()
            .Include(truck => truck.TechnicalInformation)
            .Include(truck => truck.FinancialInformation)
            .Include(truck => truck.Trailer)
            .Include(truck => truck.Driver)
            .FirstOrDefaultAsync(truck => truck.Id == request.Id, cancellationToken);

        if (truck is null)
        {
            throw new NotFoundException();
        }

        if (request.TechnicalInformation is not null)
        {
            UpdateTechnicalInformation(request.TechnicalInformation, truck);
        }

        if (request.FinancialInformation is not null)
        {
            UpdateFinancialInformation(request.FinancialInformation, truck);
        }

        if (request.TrailerId.HasValue)
        {
            Trailer? trailer = await dbContext
                .EntitySetFor<Trailer>()
                .Where(trailer => trailer.TruckId == null)
                .FirstOrDefaultAsync(trailer => trailer.Id == request.TrailerId.Value, cancellationToken);

            if (trailer is null)
            {
                throw new NotFoundException();
            }

            trailer.TruckId = truck.Id;
        }

        if (request.DriverId.HasValue)
        {
            Driver? driver = await dbContext
                .EntitySetFor<Driver>()
                .Where(driver => driver.VehicleId == null)
                .FirstOrDefaultAsync(driver => driver.Id == request.DriverId, cancellationToken);

            if (driver is null)
            {
                throw new NotFoundException();
            }

            driver.VehicleId = truck.Id;
        }
        
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
    
    private static void UpdateTechnicalInformation(TechnicalInformationUpdateDto request, Truck truck)
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

    private static void UpdateFinancialInformation(FinancialInformationUpdateDto request, Truck truck)
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