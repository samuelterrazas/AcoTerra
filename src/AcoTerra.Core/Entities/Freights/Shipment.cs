using AcoTerra.Core.Entities.Agents;
using AcoTerra.Core.Entities.Freights.Enums;
using AcoTerra.Core.Entities.Products;

namespace AcoTerra.Core.Entities.Freights;

public sealed class Shipment : AuditableEntity
{
    public int Id { get; set; }
    public required int FreightId { get; set; }
    public required string Number { get; set; }
    public required int ProducerId { get; set; }
    public required int ProductId { get; set; }
    public required decimal TotalProductQuantity { get; set; }
    public required decimal TotalProductWeight { get; set; }
    public required decimal TotalProductAmount { get; set; }
    public required int CustomerId { get; set; }
    public required string Location { get; set; }
    public required ShipmentStatus Status { get; set; }
    
    public Freight Freight { get; set; } = null!;
    public Producer Producer { get; set; } = null!;
    public Product Product { get; set; } = null!;
    public Customer Customer { get; set; } = null!;
}