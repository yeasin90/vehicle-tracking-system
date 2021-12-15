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

            builder.HasIndex(e => new { e.Id, e.SerialNumber })
                .IsUnique();

            builder.Property(e => e.CreatedDate)
                   .HasDefaultValueSql("(DATETIME('now'))");
        }
    }
}
