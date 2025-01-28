using Microsoft.EntityFrameworkCore;

namespace AcoTerra.API.Data;

public sealed class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
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