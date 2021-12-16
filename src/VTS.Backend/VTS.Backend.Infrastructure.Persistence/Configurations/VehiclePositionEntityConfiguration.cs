using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VTS.Backend.Core.Domain.Entities;

namespace VTS.Backend.Infrastructure.Persistence.Configurations
{
    public class VehiclePositionEntityConfiguration : IEntityTypeConfiguration<VehiclePosition>
    {
        public void Configure(EntityTypeBuilder<VehiclePosition> builder)
        {
            builder.Property(e => e.Latitude)
                   .IsRequired();
            builder.Property(e => e.Longitude)
                   .IsRequired();

            builder.HasIndex(e => e.VehilceId);
            builder.HasIndex(e => e.CreatedDateTimeStampInSeconds);
        }
    }
}
