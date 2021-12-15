using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace VTS.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    public class VehicleTrackerController : ControllerBase
    {
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> RegisterDeviceAsync()
        {
            return Ok();
        }
    }
}
