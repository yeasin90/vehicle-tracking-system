using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using VTS.Backend.Core.Application.Contracts;
using VTS.Backend.Core.Domain.Entities;

namespace VTS.Backend.Infrastructure.Persistence.Repositories
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(VtsDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Vehicle> GetBySerialNumberAsync(string serialNumber)
        {
            var result = await _dbContext.Vehicles.Where(x => x.SerialNumber == serialNumber).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Vehicle> GetByUserIdAndSerialNumberAsync(Guid userId, string serialNumber)
        {
            var result = await _dbContext.Vehicles.Where(x => x.UserId == userId && x.SerialNumber == serialNumber).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Vehicle> GetByUserIdAndVehicleIdAsync(Guid userId, long vehicleId)
        {
            var result = await _dbContext.Vehicles.Where(x => x.UserId == userId && x.Id == vehicleId).FirstOrDefaultAsync();
            return result;
        }
    }
}
