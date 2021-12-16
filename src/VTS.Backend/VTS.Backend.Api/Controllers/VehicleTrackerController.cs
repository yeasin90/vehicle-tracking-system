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

        /// <summary>
        ///  Register a vehicle
        /// </summary>
        /// <returns>Vehicle object created in database</returns>
        [HttpPost]
        [Route("device")]
        public async Task<ActionResult<VehicleDto>> RegisterDeviceAsync([FromBody]RegisterVehicleCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Record the position of a registered vehicle
        /// </summary>
        /// <returns>Vehicle position object created in database</returns>
        [HttpPost]
        [Route("device/position")]
        public async Task<ActionResult<VehiclePositionDto>> RegisterDevicePositionAsync([FromBody]RegisterPositionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Retrieve the current position of a vehicle
        /// </summary>
        /// <remarks>
        /// Retrieves last recorded position in database for a registered vehicle
        /// </remarks>
        /// <param name="VehicleId">Id of a registered vehicle</param>
        /// <returns>Vehicle position object</returns>
        [HttpGet]
        [Route("device/{VehicleId}/position")]
        public async Task<ActionResult<VehiclePositionDto>> GetCurrentPositionAsync(GetCurrentPositionQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Retrieve the positions of a vehicle
        /// </summary>
        /// <remarks>
        /// Retrieve the positions of a vehicle during a certain time, in order to display their journey on a map (maps drawing is out of scope)
        /// </remarks>
        /// <param name="VehicleId">Id of a registered vehicle</param>
        /// <param name="FromTimeStampInSeconds">From: time stamp in seconds</param>
        /// <param name="ToTimeStampInSeconds">To: time stamp in seconds</param>
        /// <returns>List of Vehicle position object</returns>
        [HttpGet]
        [Route("device/{VehicleId}/position/{FromTimeStampInSeconds}/{ToTimeStampInSeconds}")]
        public async Task<ActionResult> GetPositionsAsync(GetTimeIntervalPositionsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
