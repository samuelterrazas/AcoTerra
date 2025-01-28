using AcoTerra.API.Data.Entities.Vehicles.Enums;

namespace AcoTerra.API.Features.Trucks.CreateTruck;

internal sealed record CreateTruckRequest(
    string LicensePlate,
    string Brand,
    string Model,
    int ManufacturingYear,
    string ChassisNumber,
    string EngineNumber,
    double? CurrentMileage,
    FuelType? FuelType,
    double? AverageConsumption,
    double? TankSize,
    decimal? PurchasePrice,
    bool? Financed,
    int? Installments,
    decimal? OutstandingBalance
);