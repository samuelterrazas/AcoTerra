using AcoTerra.Core.Features;
using AcoTerra.Core.Features.Trucks.CreateTruck;
using AcoTerra.Core.Features.Trucks.SearchTrucks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AcoTerra.Web.Controllers;

public sealed class TrucksController(ISender sender) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<TruckResponse> trucks = await sender.Send(new SearchTrucksQuery());
        
        return View("Index", trucks);
    }
    
    #region Create
    //TODO Agregue esta clase
    [HttpGet]
    public async Task<IActionResult> CreateTruck()
    {
        var trailers = await sender.Send(new GetTrailersQuery());
        var drivers = await sender.Send(new GetDriversQuery());
        
        var model = new CreateTruckCommand
        {
            Trailers = trailers.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.LicensePlate }).ToList(),
            Drivers = drivers.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name}).ToList()
        };
        
        return View("CreateTruck", model);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTruck(CreateTruckCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View("CreateTruck", command);
        }
        
        await sender.Send(command);
        return RedirectToAction("Index");
    }
    
    #endregion
    
}