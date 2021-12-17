using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using VTS.Backend.Core.Application.Extensions;
using VTS.Backend.Core.Application.Models;

namespace VTS.Backend.Core.Application.Services
{
    public class UserService : IUserService
    {
        public readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public VtsUser GetCurrentUser()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var role = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role).Value;

            return new VtsUser()
            {
                UserId = new Guid(userId),
                Role = role.ToVtsUserRoleEnum()
            };
        }
    }
}
