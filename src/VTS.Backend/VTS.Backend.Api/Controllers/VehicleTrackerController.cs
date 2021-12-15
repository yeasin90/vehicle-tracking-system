using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace VTS.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    public class VehicleTrackerController : ControllerBase
    {
        [HttpPost]
        [Route("device")]
        public async Task<ActionResult> RegisterDeviceAsync()
        {
            return Ok();
        }

        [HttpPost]
        [Route("device/position")]
        public async Task<ActionResult> RegisterDevicePositionAsync()
        {
            return Ok();
        }
    }
}
