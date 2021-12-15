using VTS.Backend.Core.Domain.Entities;

namespace VTS.Backend.Core.Application.Contracts
{
    public interface IVehicleRepository : IAsyncRepository<Vehicle>
    {
    }
}
