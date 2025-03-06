using AcoTerra.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Common.Abstractions;

public interface IApplicationDbContext
{
    DbSet<TEntity> EntitySetFor<TEntity>() where TEntity : AuditableEntity;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}