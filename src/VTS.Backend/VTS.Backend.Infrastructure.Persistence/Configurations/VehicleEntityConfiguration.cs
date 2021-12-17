using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VTS.Backend.Core.Domain.Entities;

namespace VTS.Backend.Infrastructure.Persistence.Configurations
{
    public class VehicleEntityConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(e => e.SerialNumber)
                   .IsRequired();
            builder.Property(e => e.UserId)
                   .IsRequired();

            builder.HasIndex(e => e.Id);
            builder.HasIndex(e => e.SerialNumber);
            builder.HasIndex(e => e.UserId);
        }
    }
}
