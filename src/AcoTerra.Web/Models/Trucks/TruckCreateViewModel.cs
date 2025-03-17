using Microsoft.AspNetCore.Mvc.Rendering;

namespace AcoTerra.Web.Models.Trucks;

public class TruckCreateViewModel
{
    public string LicensePlate { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int ManufacturingYear { get; set; }
    public string ChassisNumber { get; set; }
    public string EngineNumber { get; set; }

    public int? TrailerId  { get; set; }
    public int? DriverId { get; set; }
    public IEnumerable<SelectListItem> Trailers { get; set; }
    public IEnumerable<SelectListItem> Drivers { get; set; }
}