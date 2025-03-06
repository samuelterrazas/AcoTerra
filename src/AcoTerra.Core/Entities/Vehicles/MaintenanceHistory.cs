namespace AcoTerra.Core.Entities.Vehicles;

public sealed class MaintenanceHistory : AuditableEntity
{
    public int Id { get; set; }
    public required int VehicleId { get; set; }
    public required DateOnly Date { get; set; }
    public required string Type { get; set; }
    public required decimal Cost { get; set; }
    public string? Document { get; set; }
}