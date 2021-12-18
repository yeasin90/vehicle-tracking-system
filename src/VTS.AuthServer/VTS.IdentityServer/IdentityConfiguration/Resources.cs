using IdentityServer4.Models;
using System.Collections.Generic;

namespace VTS.IdentityServer.IdentityConfiguration
{
    public class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> {"role"}
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource
                {
                    Name = "app.vts.frontend",
                    DisplayName = "Vehicle Tracking System Frontend",
                    Description = "Allow the frontend to access Vehicle Tracking System Backend Api on your behalf",
                    Scopes = new List<string> { "app.vts.frontend.read", "app.vts.frontend.write"},
                    UserClaims = new List<string> {"role"}
                },
                new ApiResource
                {
                    Name = "app.vts.api",
                    DisplayName = "Vehicle Tracking System Backend Api",
                    Description = "Allow other API (machine to machine) to access Vehicle Tracking System Backend Api on your behalf",
                    Scopes = new List<string> { "app.vts.api.read", "app.vts.api.write"}
                }
            };
        }
    }
}
