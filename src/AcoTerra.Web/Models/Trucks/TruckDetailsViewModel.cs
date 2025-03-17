using AcoTerra.Web.Models.Agents;
using AcoTerra.Web.Models.Trailers;
using AcoTerra.Web.Models.Vehicles;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AcoTerra.Web.Models.Trucks;

public class TruckDetailsViewModel
{
    public int Id { get; set; }
    public string LicensePlate { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int ManufacturingYear { get; set; }
    public string ChassisNumber { get; set; }
    public string EngineNumber { get; set; }
    public FinancialInformationDetailsViewModel FinancialInformation { get; set; }
    public TechnicalInformationDetailsViewModel TechnicalInformation { get; set; }
    public TrailerDetailsViewModel Trailer { get; set; }
    public DriverDetailsViewModel Driver { get; set; }
}