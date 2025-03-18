using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Trucks;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Trailers.GetTrailers;

public sealed record GetTrailersQuery : IQuery<List<TrailerListDto>>;


internal sealed class GetTrailersQueryHandler(
    IApplicationDbContext dbContext
) : IQueryHandler<GetTrailersQuery, List<TrailerListDto>>
{
    public async Task<List<TrailerListDto>> Handle(GetTrailersQuery request, CancellationToken cancellationToken)
    {
        return await dbContext
            .EntitySetFor<Trailer>()
            .AsNoTracking()
            .Select(trailer => (TrailerListDto)trailer)
            .ToListAsync(cancellationToken);
    }
}