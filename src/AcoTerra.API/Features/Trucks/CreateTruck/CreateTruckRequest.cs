using AcoTerra.API.Data.Entities.Actors.Enums;
using AcoTerra.API.Data.Entities.Drivers.Enums;

namespace AcoTerra.API.Features.Trucks.CreateTruck;

internal sealed record CreateTruckRequest(
    string LicensePlate,
    string Brand,
    string Model,
    int ManufacturingYear,
    string ChassisNumber,
    string EngineNumber,
    CreateTrailerDto Trailer,
    CreateDriverDto Driver
);

internal sealed record CreateTrailerDto(
    string LicensePlate,
    decimal Capacity
);

internal sealed record CreateDriverDto(
    string Name,
    IdentificationType IdentificationType,
    string IdentificationNumber,
    string PhoneNumber,
    string Email,
    EmploymentStatus EmploymentStatus,
    DateOnly DateOfBirth
);