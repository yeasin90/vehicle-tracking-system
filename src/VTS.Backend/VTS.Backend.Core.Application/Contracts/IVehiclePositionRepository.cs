using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VTS.Backend.Core.Domain.Entities;

namespace VTS.Backend.Core.Application.Contracts
{
    public interface IVehiclePositionRepository : IAsyncRepository<VehiclePosition>
    {
        Task<VehiclePosition> GetLatestPositionAsync(long vehicleId);
    }
}
