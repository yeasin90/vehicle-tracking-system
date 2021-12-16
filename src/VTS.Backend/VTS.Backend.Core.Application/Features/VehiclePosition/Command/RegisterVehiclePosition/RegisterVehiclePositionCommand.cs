using MediatR;

namespace VTS.Backend.Core.Application.Features.VehiclePosition.Command.RegisterVehiclePosition
{
    public class  RegisterVehiclePositionCommand : IRequest<RegisterVehiclePositionDto>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
