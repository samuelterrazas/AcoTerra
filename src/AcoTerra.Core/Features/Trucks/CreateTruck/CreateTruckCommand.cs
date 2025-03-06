using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Actors.Enums;
using AcoTerra.Core.Entities.Drivers.Enums;

namespace AcoTerra.Core.Features.Trucks.CreateTruck;

public sealed record CreateTruckCommand(
    string LicensePlate,
    string Brand,
    string Model,
    int ManufacturingYear,
    string ChassisNumber,
    string EngineNumber,
    CreateTrailerDto Trailer,
    CreateDriverDto Driver
) : ICommand;

public sealed record CreateTrailerDto(
    string LicensePlate,
    decimal Capacity
);

public sealed record CreateDriverDto(
    string Name,
    IdentificationType IdentificationType,
    string IdentificationNumber,
    string PhoneNumber,
    string Email,
    EmploymentStatus EmploymentStatus,
    DateOnly DateOfBirth
);