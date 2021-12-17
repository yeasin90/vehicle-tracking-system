﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VTS.Backend.Infrastructure.AuthServer;
using VTS.Backend.Infrastructure.AuthServer.Models;

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
        ///  Request a JWT token of a user from Identity Server
        /// </summary>
        /// <remarks>IdentityServer must be up and running. User must be registered in IdentityServer</remarks>
        /// <returns>Returns JWT token</returns>
        /// <param name="Username">Username of registered user in IdentityServer</param>
        /// <param name="Password">Password of registered user in IdentityServer</param>
        [HttpPost]
        [Route("token")]
        public async Task<ActionResult> GetTokenAsync([FromBody] LoginModel model)
        {
            var result = await _tokenService.GetJwtTokenAsync(model);
            return Ok(result?.AccessToken);
        }
    }
}