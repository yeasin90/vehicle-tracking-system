using System;
using VTS.Backend.Core.Application.Base;
using VTS.Backend.Core.Application.Features.Vehicle.Command.RegisterVehicle;

namespace VTS.Backend.Core.Application.Features.VehiclePosition.Command.RegisterVehiclePosition
{
    public class VehiclePositionDto : BaseDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Guid VehilceId { get; set; }
        public VehicleDto Vehilce { get; set; }
    }
}
