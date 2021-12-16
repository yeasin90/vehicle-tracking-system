using MediatR;

namespace VTS.Backend.Core.Application.Features.VehiclePosition.Command.RegisterPosition
{
    public class  RegisterPositionCommand : IRequest<VehiclePositionDto>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
