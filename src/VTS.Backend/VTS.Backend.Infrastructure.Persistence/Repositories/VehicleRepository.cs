using VTS.Backend.Core.Application.Contracts;
using VTS.Backend.Core.Domain.Entities;

namespace VTS.Backend.Infrastructure.Persistence.Repositories
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(VtsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
