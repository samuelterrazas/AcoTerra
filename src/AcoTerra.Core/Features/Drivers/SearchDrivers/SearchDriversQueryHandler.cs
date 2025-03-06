using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Drivers;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Drivers.SearchDrivers;

internal sealed class SearchDriversQueryHandler(
    IApplicationDbContext dbContext
) : IQueryHandler<SearchDriversQuery, List<DriverResponse>>
{
    public async Task<List<DriverResponse>> Handle(SearchDriversQuery request, CancellationToken cancellationToken)
    {
        return await dbContext
            .EntitySetFor<Driver>()
            .Select(driver => (DriverResponse)driver)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}