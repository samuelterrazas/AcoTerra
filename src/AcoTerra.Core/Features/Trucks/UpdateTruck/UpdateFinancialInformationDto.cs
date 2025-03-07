namespace AcoTerra.Core.Features.Trucks.UpdateTruck;

public sealed record UpdateFinancialInformationDto(
    decimal? PurchasePrice,
    bool? Financed,
    int? Installments,
    decimal? OutstandingBalance
);