using AcoTerra.Core.Entities.Actors.Enums;
using AcoTerra.Core.Entities.Drivers.Enums;

namespace AcoTerra.Core.Features.Trucks.CreateTruck;

public sealed record CreateDriverDto(
    string Name,
    IdentificationType IdentificationType,
    string IdentificationNumber,
    string PhoneNumber,
    string Email,
    EmploymentStatus EmploymentStatus,
    DateOnly DateOfBirth
);