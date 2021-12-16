using System.Collections.Generic;
using VTS.Backend.Core.Application.Base;
using VTS.Backend.Core.Application.Features.VehiclePosition.Command.RegisterVehiclePosition;

namespace VTS.Backend.Core.Application.Features.Vehicle.Command.RegisterVehicle
{
    public class VehicleDto : BaseDto
    {
        public string SerialNumber { get; set; }
        public List<VehiclePositionDto> Positions { get; set; }
    }
}
