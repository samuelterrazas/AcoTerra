namespace AcoTerra.Web.Models.Vehicles;

public class FinancialInformationDetailsViewModel
{
    public decimal PurchasePrice { get; set; }
    public bool Financed { get; set; }
    public int Installments { get; set; }
    public decimal OutstandingBalance { get; set; }
}