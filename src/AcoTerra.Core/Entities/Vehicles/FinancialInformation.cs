namespace AcoTerra.Core.Entities.Vehicles;

public sealed class FinancialInformation : AuditableEntity
{
    public int Id { get; set; }
    public decimal PurchasePrice { get; set; }
    public bool Financed { get; set; }
    public int Installments { get; set; }
    public decimal OutstandingBalance { get; set; }
}