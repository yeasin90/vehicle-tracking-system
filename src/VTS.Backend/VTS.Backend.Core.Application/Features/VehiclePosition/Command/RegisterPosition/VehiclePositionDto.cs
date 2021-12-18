using VTS.Backend.Core.Application.Base;
using VTS.Backend.Core.Application.Features.Vehicle.Command.RegisterVehicle;

namespace VTS.Backend.Core.Application.Features.VehiclePosition.Command.RegisterPosition
{
    public class VehiclePositionDto : BaseDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string LocationName { get; set; }
        public long VehicleId { get; set; }
        public VehicleDto Vehicle { get; set; }
    }
}
