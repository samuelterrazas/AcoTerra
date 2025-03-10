using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Trucks;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Trailers.SearchTrailers;

public sealed record SearchTrailersQuery(string? LicensePlate = null) : IQuery<List<TrailerSearchResultDto>>;


internal sealed class SearchTrailersQueryHandler(
    IApplicationDbContext dbContext
) : IQueryHandler<SearchTrailersQuery, List<TrailerSearchResultDto>>
{
    public async Task<List<TrailerSearchResultDto>> Handle(SearchTrailersQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Trailer> trailers = dbContext
            .EntitySetFor<Trailer>()
            //.Where(trailer => trailer) // TODO: Agregar prop de navegación
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.LicensePlate))
        {
            trailers = trailers.Where(trailer => trailer.LicensePlate.Contains(request.LicensePlate));
        }

        return await trailers
            .Select(trailer => (TrailerSearchResultDto)trailer)
            .ToListAsync(cancellationToken);
    }
}