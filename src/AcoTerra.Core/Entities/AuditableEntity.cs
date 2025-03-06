namespace AcoTerra.Core.Entities;

public abstract class AuditableEntity
{
    public DateTime LastModifiedAt { get; set; }
    public string? LastModifiedBy { get; set; }
}