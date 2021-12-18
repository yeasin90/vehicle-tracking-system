using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VTS.Backend.Core.Application.Contracts;
using VTS.Backend.Core.Domain.Entities;

namespace VTS.Backend.Infrastructure.Persistence.Repositories
{
    public class VehiclePositionRepository : BaseRepository<VehiclePosition>, IVehiclePositionRepository
    {
        public VehiclePositionRepository(VtsDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<VehiclePosition> GetLatestPositionAsync(long vehicleId)
        {
            var result = await _dbContext.VehiclePositions
                .OrderByDescending(x => x.CreatedDateTimeStampInSeconds)
                .Where(x => x.VehicleId == vehicleId)
                .FirstOrDefaultAsync();
            return result;
        }
    }
}
