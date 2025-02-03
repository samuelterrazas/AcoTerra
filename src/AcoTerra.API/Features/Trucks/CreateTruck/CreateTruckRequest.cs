namespace AcoTerra.API.Features.Trucks.CreateTruck;

internal sealed record CreateTruckRequest(
    string LicensePlate,
    string Brand,
    string Model,
    int ManufacturingYear,
    string ChassisNumber,
    string EngineNumber,
    CreateTrailerDto? Trailer
);

internal sealed record CreateTrailerDto(
    string LicensePlate,
    decimal Capacity
);