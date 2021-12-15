using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VTS.Backend.Core.Domain.Entities;

namespace VTS.Backend.Infrastructure.Persistence
{
    public class VtsDbContext : DbContext
    {
        public VtsDbContext(DbContextOptions<VtsDbContext> options) : base(options)
        {

        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehiclePosition> VehiclePositions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
