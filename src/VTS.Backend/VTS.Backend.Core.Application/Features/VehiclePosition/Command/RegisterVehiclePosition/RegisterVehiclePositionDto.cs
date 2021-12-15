using System;
using VTS.Backend.Core.Application.Base;

namespace VTS.Backend.Core.Application.Features.VehiclePosition.Command.RegisterVehiclePosition
{
    public class RegisterVehiclePositionDto : BaseDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Guid VehicleId { get; set; }
    }
}
