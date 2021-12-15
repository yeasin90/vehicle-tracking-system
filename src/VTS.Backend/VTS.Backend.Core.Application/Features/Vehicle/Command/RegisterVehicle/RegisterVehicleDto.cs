using VTS.Backend.Core.Application.Base;

namespace VTS.Backend.Core.Application.Features.Vehicle.Command.RegisterVehicle
{
    public class RegisterVehicleDto : BaseDto
    {
        public string SerialNumber { get; set; }
    }
}
