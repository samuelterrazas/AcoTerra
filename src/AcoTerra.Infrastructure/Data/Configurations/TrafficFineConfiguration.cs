using AcoTerra.Core.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoTerra.Infrastructure.Data.Configurations;

internal sealed class TrafficFineConfiguration : IEntityTypeConfiguration<TrafficFine>
{
    public void Configure(EntityTypeBuilder<TrafficFine> builder)
    {
        builder.ToTable("traffic_fines");

        builder.HasKey(trafficFine => trafficFine.Id);
        
        builder.Property(trafficFine => trafficFine.Id)
            .ValueGeneratedOnAdd();
    }
}