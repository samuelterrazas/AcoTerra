using AcoTerra.API.Data.Entities.Vehicles.Enums;

namespace AcoTerra.API.Features.Trucks.UpdateTruck;

internal sealed record UpdateTruckRequest(
    UpdateTechnicalInformationRequest? TechnicalInfo,
    UpdateFinancialInformationRequest? FinancialInfo,
    UpdateTrailerRequest? Trailer
);

internal sealed record UpdateTechnicalInformationRequest(
    double? CurrentMileage,
    FuelType? FuelType,
    double? AverageConsumption,
    double? TankSize
);

internal sealed record UpdateFinancialInformationRequest(
    decimal? PurchasePrice,
    bool? Financed,
    int? Installments,
    decimal? OutstandingBalance
);

internal sealed record UpdateTrailerRequest(
    string? LicensePlate,
    double? Capacity
);