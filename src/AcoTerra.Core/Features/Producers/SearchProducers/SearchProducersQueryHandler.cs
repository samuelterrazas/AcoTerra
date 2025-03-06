using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Producers;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Producers.SearchProducers;

internal sealed class SearchProducersQueryHandler(
    IApplicationDbContext dbContext
) : IQueryHandler<SearchProducersQuery, List<ProducerResponse>>
{
    public async Task<List<ProducerResponse>> Handle(SearchProducersQuery request, CancellationToken cancellationToken)
    {
        return await dbContext
            .EntitySetFor<Producer>()
            .Select(producer => (ProducerResponse)producer)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}