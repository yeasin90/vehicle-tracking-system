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

        public async Task<VehiclePosition> GetLatestPositionAsync(long vehicleId)
        {
            var result = await _dbContext.VehiclePositions
                .OrderByDescending(x => x.CreatedDateTimeStampInSeconds)
                .Where(x => x.VehicleId == vehicleId)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<VehiclePosition>> GetPositionsAsync(long vehicleId, double fromTimeStampInSeconds, double toTimeStampInSeconds)
        {
            var result = await _dbContext.VehiclePositions
                .Where(x => x.VehicleId == vehicleId 
                && x.CreatedDateTimeStampInSeconds >= fromTimeStampInSeconds
                && x.CreatedDateTimeStampInSeconds <= toTimeStampInSeconds)
                .OrderBy(x => x.CreatedDateTimeStampInSeconds)
                .Select(x => new VehiclePosition()
                {
                    Id = x.Id,
                    Latitude = x.Latitude,
                    Longitude = x.Longitude,
                    VehicleId = x.VehicleId,
                    CreatedDateTimeStampInSeconds = x.CreatedDateTimeStampInSeconds
                })
                .ToListAsync();
            return result;
        }
    }
}
