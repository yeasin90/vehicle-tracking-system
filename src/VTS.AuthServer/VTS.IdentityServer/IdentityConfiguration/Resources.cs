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
                    Name = "app.api.vts",
                    DisplayName = "Vehicle Tracking System Backend Api",
                    Description = "Allow the application to access Vehicle Tracking System Backend Api on your behalf",
                    Scopes = new List<string> { "app.api.vts.read", "app.api.vts.write"},
                    UserClaims = new List<string> {"role"}
                }
            };
        }
    }
}
