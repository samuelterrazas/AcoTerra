using AcoTerra.Web.Models.Trucks;
using AcoTerra.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AcoTerra.Web.Controllers;

public sealed class TrucksController(ITruckService truckService, ITrailerService trailerService, IAgentService agentService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        List<TruckListViewModel> trucks = await truckService.GetTrucks(cancellationToken);
        
        return View("Index", trucks);
    }
    
    #region Create
    
    [HttpGet]
    public async Task<IActionResult> Create(CancellationToken cancellationToken)
    {
         var trailers = await trailerService.SearchTrailer(null, cancellationToken);
         var drivers = await agentService.SearchDrivers(null, cancellationToken);
        
         var model = new TruckCreateViewModel
         {
             Trailers = trailers.Select(x => new SelectListItem
             {
                 Value = x.Id.ToString(),
                 Text = x.LicensePlate
             }),
             Drivers = drivers.Select(x => new SelectListItem
             {
                 Value = x.Id.ToString(),
                 Text = x.Name
             })
         };
        
        return View("Create", model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TruckCreateViewModel truckModel, CancellationToken cancellationToken)
    {
        // if (!ModelState.IsValid)
        // {
        //     // Recargar listas en caso de error
        //     truckModel.Trailers = (await trailerService.SearchTrailer(null, cancellationToken))
        //         .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.LicensePlate });
        //
        //     truckModel.Drivers = (await agentService.SearchDrivers(null, cancellationToken))
        //         .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
        //     
        //     return View("Create", truckModel);
        // }
        
        await truckService.CreateTruck(truckModel, cancellationToken);
        return RedirectToAction("Index");
    }
    
    #endregion
    
    public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
    {
        var truck = await truckService.GetTruckById(id, cancellationToken);

        if (truck == null)
        {
            return NotFound();
        }

        return View("Details", truck);
    }
}