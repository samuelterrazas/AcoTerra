using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Trucks;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features;
//TODO Agregue esta funcionalidad
public sealed record GetTrailersQuery : IQuery<List<Trailer>>
{
    internal sealed class GetTrailersQueryHandler(IApplicationDbContext dbContext) : IQueryHandler<GetTrailersQuery, List<Trailer>>
    {
        public async Task<List<Trailer>> Handle(GetTrailersQuery request, CancellationToken cancellationToken)
        {
            return await dbContext
                .EntitySetFor<Trailer>()
                .AsNoTracking()
                .Select(trailer => new Trailer
                {
                    Id = trailer.Id,
                    LicensePlate = trailer.LicensePlate,
                    Capacity = trailer.Capacity
                    
                })
                .ToListAsync(cancellationToken);
        }
    }
}