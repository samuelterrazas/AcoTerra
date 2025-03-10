﻿using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Agents;
using AcoTerra.Core.Entities.Trucks;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Trucks.UpdateTruck;

public sealed record UpdateTruckCommand(
    int Id,
    TechnicalInformationUpdateDto? TechnicalInformation,
    FinancialInformationUpdateDto? FinancialInformation,
    int? TrailerId,
    int? DriverId
) : ICommand;


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
            .Include(truck => truck.Driver)
            .FirstOrDefaultAsync(truck => truck.Id == request.Id, cancellationToken);

        if (truck is null)
        {
            throw new Exception("The requested resource could not be found.");
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
                throw new Exception("The requested resource could not be found.");
            }
            
            truck.Trailer = trailer;
        }

        if (request.DriverId.HasValue)
        {
            Driver? driver = await dbContext
                .EntitySetFor<Driver>()
                .Where(driver => driver.VehicleId == null)
                .FirstOrDefaultAsync(driver => driver.Id == request.DriverId, cancellationToken);

            if (driver is null)
            {
                throw new Exception("The requested resource could not be found.");
            }
            
            truck.Driver = driver;
        }

        await dbContext.SaveChangesAsync(cancellationToken);
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