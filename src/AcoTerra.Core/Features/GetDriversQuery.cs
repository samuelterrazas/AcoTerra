using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Drivers;
using AcoTerra.Core.Features.Drivers.SearchDrivers;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features;
//TODO Agregue esta funcionalidad
public sealed record GetDriversQuery() : IQuery<List<Driver>>;

internal sealed class GetDriversQueryHandler(IApplicationDbContext dbContext) : IQueryHandler<GetDriversQuery, List<Driver>>
{
    public async Task<List<Driver>> Handle(GetDriversQuery request, CancellationToken cancellationToken)
    {
        return await dbContext
            .EntitySetFor<Driver>()
            .AsNoTracking()
            .Select(driver => new Driver
            {
                Id = driver.Id,
                Name = driver.Name,
                DateOfBirth = driver.DateOfBirth,
                PhoneNumber = driver.PhoneNumber,
                Email = driver.Email,
                EmploymentStatus = driver.EmploymentStatus,
                IdentificationNumber = driver.IdentificationNumber,
                IdentificationType = driver.IdentificationType,
            })
            .ToListAsync(cancellationToken);
    }
}