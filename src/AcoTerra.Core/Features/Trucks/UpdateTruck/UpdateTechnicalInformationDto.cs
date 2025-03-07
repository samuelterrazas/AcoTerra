using AcoTerra.Core.Entities.Vehicles.Enums;

namespace AcoTerra.Core.Features.Trucks.UpdateTruck;

public sealed record UpdateTechnicalInformationDto(
    decimal? CurrentMileage,
    FuelType? FuelType,
    decimal? AverageConsumption,
    decimal? TankSize
);