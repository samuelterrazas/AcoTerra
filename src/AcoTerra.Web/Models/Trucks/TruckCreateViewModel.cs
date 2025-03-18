using Microsoft.AspNetCore.Mvc.Rendering;

namespace AcoTerra.Web.Models.Trucks;

public sealed class TruckCreateViewModel
{
    public string LicensePlate { get; init; }
    public string Brand { get; init; }
    public string Model { get; init; }
    public int ManufacturingYear { get; init; }
    public string ChassisNumber { get; init; }
    public string EngineNumber { get; init; }

    public int? TrailerId  { get; init; }
    public int? DriverId { get; init; }
    public IEnumerable<SelectListItem> Trailers { get; init; }
    public IEnumerable<SelectListItem> Drivers { get; init; }
}