using AcoTerra.API.Data.Entities.Actors;
using AcoTerra.API.Data.Entities.Drivers.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.API.Data.Entities.Drivers;

internal sealed class Driver : Actor
{
    public required EmploymentStatus EmploymentStatus { get; set; }
    public required DateOnly DateOfBirth { get; set; }
    public string? EmergencyContact { get; set; }
}

internal sealed class DriverConfiguration : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.ToTable("drivers");
        
        builder.Property(driver => driver.Id)
            .ValueGeneratedOnAdd();
    }
}