using AcoTerra.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.API.Common.Abstractions;

internal interface IApplicationDbContext
{
    DbSet<TEntity> EntitySetFor<TEntity>() where TEntity : AuditableEntity;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}