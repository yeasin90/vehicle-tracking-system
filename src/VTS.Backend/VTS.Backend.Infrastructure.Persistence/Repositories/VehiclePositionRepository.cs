using VTS.Backend.Core.Application.Contracts;
using VTS.Backend.Core.Domain.Entities;

namespace VTS.Backend.Infrastructure.Persistence.Repositories
{
    public class VehiclePositionRepository : BaseRepository<VehiclePosition>, IVehiclePositionRepository
    {
        public VehiclePositionRepository(VtsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
