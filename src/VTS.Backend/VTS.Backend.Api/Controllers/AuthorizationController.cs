using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VTS.Backend.Infrastructure.AuthServer;

namespace VTS.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthorizationController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        /// <summary>
        ///  Get JWT token of a user from Identity Server
        /// </summary>
        /// <returns>Returns JWT token response</returns>
        /// <param name="Username">Username of registered user in IdentityServer</param>
        /// <param name="Password">Password of registered user in IdentityServer</param>
        [HttpPost]
        [Route("token")]
        public async Task<ActionResult> RegisterDeviceAsync([FromBody] LoginModel model)
        {
            var result = await _tokenService.GetJwtTokenAsync(model.Username, model.Password);
            return Ok(result?.AccessToken);
        }
    }
}
