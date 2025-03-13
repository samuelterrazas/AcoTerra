using AcoTerra.Web.Models.Trucks;
using Refit;

namespace AcoTerra.Web.Services;

public interface ITruckService
{
    [Get("")]
    Task<List<TruckListViewModel>> GetTrucks(CancellationToken cancellationToken);
}