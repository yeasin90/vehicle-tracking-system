using IdentityServer4.Models;
using System.Collections.Generic;

namespace VTS.IdentityServer.IdentityConfiguration
{
    public class Scopes
    {
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope("app.api.vts.read", "Read Access to Vehicle Tracking System API"),
                new ApiScope("app.api.vts.write", "Write Access to Vehicle Tracking System API"),
            };
        }
    }
}
