using AcoTerra.Core.Entities.Trucks;

namespace AcoTerra.Core.Entities.Freights;

public sealed class Freight : AuditableEntity
{
    public int Id { get; set; }
    public required string Number { get; set; }
    public required int TruckId { get; set; }
    public required DateOnly LoadingDate { get; set; }
    public required DateOnly UnloadingDate { get; set; }
    public decimal TotalShipmentQuantity { get; set; }
    public decimal TotalShipmentWeight { get; set; }
    public decimal TotalShipmentAmount { get; set; }
    public string? Remarks { get; set; }
    
    
    public Truck Truck { get; set; } = null!;
    public ICollection<Shipment> Shipments { get; set; } = [];
}