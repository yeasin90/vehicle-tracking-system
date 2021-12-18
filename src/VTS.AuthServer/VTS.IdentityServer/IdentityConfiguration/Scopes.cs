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
                new ApiScope("app.vts.frontend.read", "Read Access to Vehicle Tracking Frontendt"),
                new ApiScope("app.vts.frontend.write", "Write Access to Vehicle Tracking Frontendt"),
                new ApiScope("app.vts.api.read", "Read Access to Vehicle Tracking Backend API"),
                new ApiScope("app.vts.api.write", "Write Access to Vehicle Tracking Backend API")
            };
        }
    }
}
