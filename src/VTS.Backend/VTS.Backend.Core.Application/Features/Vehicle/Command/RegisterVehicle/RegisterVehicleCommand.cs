using MediatR;

namespace VTS.Backend.Core.Application.Features.Vehicle.Command.RegisterVehicle
{
    public class RegisterVehicleCommand : IRequest<RegisterVehicleDto>
    {
        public string SerialNumber { get; set; }
    }
}
