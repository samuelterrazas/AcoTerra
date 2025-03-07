using System.Text.Json;
using AcoTerra.Core.Features.Trucks.SearchTrucks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcoTerra.Web.Controllers;

public sealed class TrucksController(ISender sender) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<TruckResponse> trucks = await sender.Send(new SearchTrucksQuery());
        
        return View("Index", trucks);
    }
}