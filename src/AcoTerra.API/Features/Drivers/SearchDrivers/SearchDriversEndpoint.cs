using AcoTerra.API.Common.Abstractions;
using AcoTerra.API.Data.Entities.Drivers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.API.Features.Drivers.SearchDrivers;

internal sealed class SearchDriversEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapGet("/", Handle);
    
    private static async Task<Ok<List<DriverResponse>>> Handle(
        IApplicationDbContext dbContext,
        CancellationToken cancellationToken
    )
    {
        List<DriverResponse> drivers = await dbContext
            .EntitySetFor<Driver>()
            .Select(driver => (DriverResponse)driver)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        
        return TypedResults.Ok(drivers);
    }
}