namespace AcoTerra.Core.Entities.Trucks;

public sealed class Trailer : AuditableEntity
{
    public int Id { get; set; }
    public required string LicensePlate { get; set; }
    public decimal Capacity { get; set; }
}