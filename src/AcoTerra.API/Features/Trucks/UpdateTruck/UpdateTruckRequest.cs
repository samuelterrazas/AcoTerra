using AcoTerra.API.Data.Entities.Vehicles.Enums;

namespace AcoTerra.API.Features.Trucks.UpdateTruck;

internal sealed record UpdateTruckRequest(
    double? CurrentMileage,
    FuelType? FuelType,
    double? AverageConsumption,
    double? TankSize,
    decimal? PurchasePrice,
    bool? Financed,
    int? Installments,
    decimal? OutstandingBalance
);