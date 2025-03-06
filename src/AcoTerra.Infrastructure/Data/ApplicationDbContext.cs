using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Infrastructure.Data;

public sealed class ApplicationDbContext(DbContextOptions options) : DbContext(options), IApplicationDbContext
{
    public DbSet<TEntity> EntitySetFor<TEntity>() where TEntity : AuditableEntity => Set<TEntity>();
    
    
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<bool>().HaveColumnType("INTEGER");
        configurationBuilder.Properties<DateTime>().HaveColumnType("TEXT");
        configurationBuilder.Properties<DateOnly>().HaveColumnType("TEXT");
        
        base.ConfigureConventions(configurationBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}