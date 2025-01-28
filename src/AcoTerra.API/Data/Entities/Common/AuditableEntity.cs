namespace AcoTerra.API.Data.Entities.Common;

public abstract class AuditableEntity
{
    public DateTime LastModifiedAt { get; set; }
    public string? LastModifiedBy { get; set; }
}