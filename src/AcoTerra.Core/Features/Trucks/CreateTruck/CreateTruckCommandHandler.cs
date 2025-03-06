using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Drivers;
using AcoTerra.Core.Entities.Trucks;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Trucks.CreateTruck;

internal sealed class CreateTruckCommandHandler(
    IApplicationDbContext dbContext
) : ICommandHandler<CreateTruckCommand>
{
    public async Task Handle(CreateTruckCommand request, CancellationToken cancellationToken)
    {
        bool isTrailerRegistered = await dbContext
            .EntitySetFor<Trailer>()
            .AsNoTracking()
            .AnyAsync(trailer => trailer.LicensePlate == request.Trailer.LicensePlate, cancellationToken);

        if (isTrailerRegistered)
        {
            throw new Exception("Trailer already registered.");
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
            Driver = new Driver
            {
                Name = request.Driver.Name,
                IdentificationType = request.Driver.IdentificationType,
                IdentificationNumber = request.Driver.IdentificationNumber,
                PhoneNumber = request.Driver.PhoneNumber,
                Email = request.Driver.Email,
                EmploymentStatus = request.Driver.EmploymentStatus,
                DateOfBirth = request.Driver.DateOfBirth,
            },
        };

        dbContext.EntitySetFor<Truck>().Add(truck);
        
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}