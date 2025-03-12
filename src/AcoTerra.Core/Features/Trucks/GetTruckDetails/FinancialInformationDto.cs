using AcoTerra.Core.Entities.Vehicles;

namespace AcoTerra.Core.Features.Trucks.GetTruckDetails;

public sealed record FinancialInformationDto(
    decimal PurchasePrice,
    bool Financed,
    int Installments,
    decimal OutstandingBalance
)
{
    public static explicit operator FinancialInformationDto(FinancialInformation financialInfo)
    {
        return new FinancialInformationDto(
            PurchasePrice: financialInfo.PurchasePrice,
            Financed: financialInfo.Financed,
            Installments: financialInfo.Installments,
            OutstandingBalance: financialInfo.OutstandingBalance
        );
    }
}