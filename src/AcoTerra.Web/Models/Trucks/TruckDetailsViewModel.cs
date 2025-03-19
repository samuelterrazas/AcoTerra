using AcoTerra.Web.Models.Agents;
using AcoTerra.Web.Models.Trailers;
using AcoTerra.Web.Models.Vehicles;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AcoTerra.Web.Models.Trucks;

public sealed class TruckDetailsViewModel
{
    public int Id { get; init; }
    public string? LicensePlate { get; init; }
    public string? Brand { get; init; }
    public string? Model { get; init; }
    public int ManufacturingYear { get; init; }
    public string? ChassisNumber { get; init; }
    public string? EngineNumber { get; init; }
    public FinancialInformationDetailsViewModel? FinancialInformation { get; init; }
    public TechnicalInformationDetailsViewModel? TechnicalInformation { get; init; }
    public TrailerDetailsViewModel? Trailer { get; init; }
    public DriverDetailsViewModel? Driver { get; init; }
}