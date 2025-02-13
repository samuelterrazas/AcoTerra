﻿using AcoTerra.API.Data.Entities.Vehicles.Enums;

namespace AcoTerra.API.Features.Trucks.UpdateTruck;

internal sealed record UpdateTruckRequest(
    UpdateTechnicalInformationDto? TechnicalInfo,
    UpdateFinancialInformationDto? FinancialInfo
);

internal sealed record UpdateTechnicalInformationDto(
    decimal? CurrentMileage,
    FuelType? FuelType,
    decimal? AverageConsumption,
    decimal? TankSize
);

internal sealed record UpdateFinancialInformationDto(
    decimal? PurchasePrice,
    bool? Financed,
    int? Installments,
    decimal? OutstandingBalance
);