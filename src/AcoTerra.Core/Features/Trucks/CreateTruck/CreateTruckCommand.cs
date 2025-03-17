using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Common.Exceptions;
using AcoTerra.Core.Entities.Agents;
using AcoTerra.Core.Entities.Trucks;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Trucks.CreateTruck;

public sealed record CreateTruckCommand(
    string LicensePlate,
    string Brand,
    string Model,
    int ManufacturingYear,
    string ChassisNumber,
    string EngineNumber,
    int TrailerId,
    int DriverId
) : ICommand<int>;


internal sealed class CreateTruckCommandHandler(
    IApplicationDbContext dbContext
) : ICommandHandler<CreateTruckCommand, int>
{
    public async Task<int> Handle(CreateTruckCommand request, CancellationToken cancellationToken)
    {
        Trailer? trailer = await dbContext
            .EntitySetFor<Trailer>()
            .Where(trailer => trailer.TruckId == null)
            .FirstOrDefaultAsync(trailer => trailer.Id == request.TrailerId, cancellationToken);

        if (trailer is null)
        {
            throw new NotFoundException();
        }
        
        Driver? driver = await dbContext
            .EntitySetFor<Driver>()
            .Where(driver => driver.VehicleId == null)
            .FirstOrDefaultAsync(driver => driver.Id == request.DriverId, cancellationToken);

        if (driver is null)
        {
            throw new NotFoundException();
        }
        
        var truck = new Truck
        {
            LicensePlate = request.LicensePlate,
            Brand = request.Brand,
            Model = request.Model,
            ManufacturingYear = request.ManufacturingYear,
            ChassisNumber = request.ChassisNumber,
            EngineNumber = request.EngineNumber,
            Trailer = trailer,
            Driver = driver,
        };

        dbContext.EntitySetFor<Truck>().Add(truck);
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return truck.Id;
    }
}