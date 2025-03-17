using AcoTerra.Web.Models.Trucks;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace AcoTerra.Web.Services;

public interface ITruckService
{
    [Get("/")]
    Task<List<TruckListViewModel>> GetTrucks(CancellationToken cancellationToken);
    
    [Post("/")]
    Task CreateTruck(TruckCreateViewModel createViewModel, CancellationToken cancellationToken); 
    
    [Get("/{id}")]
    Task<TruckDetailsViewModel> GetTruckById(int id, CancellationToken cancellationToken); 
}