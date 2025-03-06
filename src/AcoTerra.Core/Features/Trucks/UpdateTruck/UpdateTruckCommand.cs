using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Vehicles.Enums;

namespace AcoTerra.Core.Features.Trucks.UpdateTruck;

public sealed record UpdateTruckCommand(
    int Id,
    UpdateTechnicalInformationDto? TechnicalInfo,
    UpdateFinancialInformationDto? FinancialInfo
) : ICommand;

public sealed record UpdateTechnicalInformationDto(
    decimal? CurrentMileage,
    FuelType? FuelType,
    decimal? AverageConsumption,
    decimal? TankSize
);

public sealed record UpdateFinancialInformationDto(
    decimal? PurchasePrice,
    bool? Financed,
    int? Installments,
    decimal? OutstandingBalance
);