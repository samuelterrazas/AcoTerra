namespace AcoTerra.Core.Features.Trucks.UpdateTruck;

public sealed record FinancialInformationUpdateDto(
    decimal? PurchasePrice,
    bool? Financed,
    int? Installments,
    decimal? OutstandingBalance
);