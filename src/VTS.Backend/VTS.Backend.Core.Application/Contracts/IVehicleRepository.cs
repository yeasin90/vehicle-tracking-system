using System;
using System.Threading.Tasks;
using VTS.Backend.Core.Domain.Entities;

namespace VTS.Backend.Core.Application.Contracts
{
    public interface IVehicleRepository : IAsyncRepository<Vehicle>
    {
        Task<Vehicle> GetBySerialNumberAsync(string serialNumber);
        Task<Vehicle> GetByUserIdAndSerialNumberAsync(Guid userId, string serialNumber);
        Task<Vehicle> GetByUserIdAndVehicleIdAsync(Guid userId, long vehicleId);
    }
}
