using AcoTerra.Web.Models.Trucks;
using AcoTerra.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcoTerra.Web.Controllers;

public sealed class TrucksController(ITruckService service) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        List<TruckListViewModel> trucks = await service.GetTrucks(cancellationToken);
        
        return View("Index", trucks);
    }
}