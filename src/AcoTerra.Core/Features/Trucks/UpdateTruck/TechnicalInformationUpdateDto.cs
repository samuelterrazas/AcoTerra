using AcoTerra.Core.Entities.Vehicles.Enums;

namespace AcoTerra.Core.Features.Trucks.UpdateTruck;

public sealed record TechnicalInformationUpdateDto(
    decimal? CurrentMileage,
    FuelType? FuelType,
    decimal? AverageConsumption,
    decimal? TankSize
);