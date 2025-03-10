using AcoTerra.Core.Features.Trucks.GetTrucks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcoTerra.Web.Controllers;

public sealed class TrucksController(ISender sender) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<TruckListDto> trucks = await sender.Send(new GetTrucksQuery());
        
        return View("Index", trucks);
    }
}