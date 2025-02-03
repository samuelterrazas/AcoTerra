using AcoTerra.API.Common.Abstractions;
using AcoTerra.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.API.Data;

internal sealed class ApplicationDbContext(DbContextOptions options) : DbContext(options), IApplicationDbContext
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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}