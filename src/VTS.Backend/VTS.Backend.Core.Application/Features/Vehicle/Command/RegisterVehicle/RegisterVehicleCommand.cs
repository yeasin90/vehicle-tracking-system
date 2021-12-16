using MediatR;

namespace VTS.Backend.Core.Application.Features.Vehicle.Command.RegisterVehicle
{
    public class RegisterVehicleCommand : IRequest<VehicleDto>
    {
        public string SerialNumber { get; set; }
    }
}
