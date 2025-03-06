namespace AcoTerra.Core.Entities.Vehicles;

public sealed class TrafficFine : AuditableEntity
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public required string Violation { get; set; }
    public required decimal Amount { get; set; }
    public required DateTime DateIssued { get; set; }
    public DateOnly? PaidAt { get; set; }
    public string? Document { get; set; }
}