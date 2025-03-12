using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Agents;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Agents.SearchDrivers;

public sealed record SearchDriversQuery(
    string? Name = null
) : IQuery<List<DriverSearchResultDto>>;


internal sealed class SearchDriversQueryHandler(
    IApplicationDbContext dbContext
) : IQueryHandler<SearchDriversQuery, List<DriverSearchResultDto>>
{
    public async Task<List<DriverSearchResultDto>> Handle(SearchDriversQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Driver> drivers = dbContext
            .EntitySetFor<Driver>()
            .Where(driver => driver.VehicleId == null)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Name))
        {
            drivers = drivers.Where(driver => driver.Name.Contains(request.Name));
        }

        return await drivers
            .Select(driver => DriverSearchResultDto.Map(driver))
            .ToListAsync(cancellationToken);
    }
}