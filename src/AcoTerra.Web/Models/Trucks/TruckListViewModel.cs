namespace AcoTerra.Web.Models.Trucks;

public sealed class TruckListViewModel
{
    public int Id { get; init; }
    public string? LicensePlate { get; init; }
    public string? Brand { get; init; }
    public string? Model { get; init; }
    public int ManufacturingYear { get; init; }
    public string? ChassisNumber { get; init; }
    public string? EngineNumber { get; init; }
}