namespace AcoTerra.Web.Models.Vehicles;

public sealed class FinancialInformationDetailsViewModel
{
    public decimal PurchasePrice { get; init; }
    public bool Financed { get; init; }
    public int Installments { get; init; }
    public decimal OutstandingBalance { get; init; }
}