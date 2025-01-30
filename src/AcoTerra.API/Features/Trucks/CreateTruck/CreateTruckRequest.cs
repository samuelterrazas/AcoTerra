namespace AcoTerra.API.Features.Trucks.CreateTruck;

internal sealed record CreateTruckRequest(
    string LicensePlate,
    string Brand,
    string Model,
    int ManufacturingYear,
    string ChassisNumber,
    string EngineNumber,
    CreateTrailerRequest? Trailer
);

internal sealed record CreateTrailerRequest(
    string LicensePlate,
    double Capacity
);