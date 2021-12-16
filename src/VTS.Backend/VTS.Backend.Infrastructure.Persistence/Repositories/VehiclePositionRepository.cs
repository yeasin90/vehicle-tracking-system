using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<VehiclePosition> GetLatestPositionAsync(Guid vehicleId)
        {
            var result = await _dbContext.VehiclePositions
                .OrderByDescending(x => x.CreatedDateTimeStampInSeconds)
                .Where(x => x.VehilceId == vehicleId)
                .Include(x => x.Vehilce)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<VehiclePosition>> GetPositionsAsync(Guid vehicleId, double fromTimeStampInSeconds, double toTimeStampInSeconds)
        {
            var result = await _dbContext.VehiclePositions
                .Where(x => x.VehilceId == vehicleId 
                && x.CreatedDateTimeStampInSeconds >= fromTimeStampInSeconds
                && x.CreatedDateTimeStampInSeconds <= toTimeStampInSeconds)
                .OrderBy(x => x.CreatedDateTimeStampInSeconds)
                .ToListAsync();
            return result;
        }
    }
}
