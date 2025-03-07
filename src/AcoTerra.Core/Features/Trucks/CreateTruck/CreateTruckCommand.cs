using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Trucks;

namespace AcoTerra.Core.Features.Trucks.CreateTruck;

public sealed record CreateTruckCommand(
    string LicensePlate,
    string Brand,
    string Model,
    int ManufacturingYear,
    string ChassisNumber,
    string EngineNumber,
    int DriverId,
    int TrailerId
) : ICommand;


internal sealed class CreateTruckCommandHandler(
    IApplicationDbContext dbContext
) : ICommandHandler<CreateTruckCommand>
{
    public async Task Handle(CreateTruckCommand request, CancellationToken cancellationToken)
    {
        // TODO: Agregar restricción desde la DB
        // bool isTrailerRegistered = await dbContext
        //     .EntitySetFor<Trailer>()
        //     .AsNoTracking()
        //     .AnyAsync(trailer => trailer.LicensePlate == request.Trailer.LicensePlate, cancellationToken);
        //
        // if (isTrailerRegistered)
        // {
        //     throw new Exception("Trailer already registered.");
        // }
        
        var truck = new Truck
        {
            LicensePlate = request.LicensePlate,
            Brand = request.Brand,
            Model = request.Model,
            ManufacturingYear = request.ManufacturingYear,
            ChassisNumber = request.ChassisNumber,
            EngineNumber = request.EngineNumber,
            DriverId = request.DriverId,
            TrailerId = request.TrailerId,
        };

        dbContext.EntitySetFor<Truck>().Add(truck);
        
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}