using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VTS.Backend.Core.Application.Features.Vehicle.Command.RegisterVehicle;
using VTS.Backend.Core.Application.Features.VehiclePosition.Command.RegisterPosition;
using VTS.Backend.Core.Application.Features.VehiclePosition.Query.GetCurrentPosition;

namespace VTS.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    public class VehicleTrackerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleTrackerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("device")]
        public async Task<ActionResult<VehicleDto>> RegisterDeviceAsync(RegisterVehicleCommand registerVehicle)
        {
            var result = await _mediator.Send(registerVehicle);
            return Ok(result);
        }

        [HttpPost]
        [Route("device/position")]
        public async Task<ActionResult<VehiclePositionDto>> RegisterDevicePositionAsync(RegisterPositionCommand registerVehiclePosition)
        {
            var result = await _mediator.Send(registerVehiclePosition);
            return Ok(result);
        }

        [HttpGet]
        [Route("device/position")]
        public async Task<ActionResult<VehiclePositionDto>> GetCurrentPositionAsync(GetCurrentPositionQuery currentPositionQuery)
        {
            var result = await _mediator.Send(currentPositionQuery);
            return Ok(result);
        }
    }
}
