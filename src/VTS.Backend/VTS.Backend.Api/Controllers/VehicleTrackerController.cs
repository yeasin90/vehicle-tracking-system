using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VTS.Backend.Core.Application.Features.Vehicle.Command.RegisterVehicle;
using VTS.Backend.Core.Application.Features.VehiclePosition.Command.RegisterPosition;
using VTS.Backend.Core.Application.Features.VehiclePosition.Query.GetCurrentPosition;
using VTS.Backend.Core.Application.Features.VehiclePosition.Query.GetTimeIntervalPositions;

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
        public async Task<ActionResult<VehicleDto>> RegisterDeviceAsync(RegisterVehicleCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [Route("device/position")]
        public async Task<ActionResult<VehiclePositionDto>> RegisterDevicePositionAsync(RegisterPositionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("device/{VehicleId}/position")]
        public async Task<ActionResult<VehiclePositionDto>> GetCurrentPositionAsync(GetCurrentPositionQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("device/{VehicleId}/position/{FromTimeStampInSeconds}/{ToTimeStampInSeconds}")]
        public async Task<ActionResult> GetPositionsAsync(GetTimeIntervalPositionsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
