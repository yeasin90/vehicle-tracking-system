using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace VTS.IdentityServer.IdentityConfiguration
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "VTS.Backend.Api",
                    ClientName = "VTS.Backend.Api",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AccessTokenType = AccessTokenType.Jwt,
                    AccessTokenLifetime = 1800,
                    ClientSecrets = new List<Secret> {new Secret("VTS.Backend.Api.Secret".Sha256())},
                    AllowedScopes = new List<string> { "app.vts.api.read", "app.vts.api.write" }
                },
                new Client
                {
                    ClientId = "VTS.Frontend",
                    ClientName = "VTS.Frontend",
                    ClientSecrets = new List<Secret> {new Secret("VTS.Frontend.Secret".Sha256())},
                    AccessTokenType = AccessTokenType.Jwt,
                    AccessTokenLifetime = 1800,
                    // Below, GrantTypes.Code is not used, reason is there is no front-end application
                    // A jwt token will be requested from VTS.Backend.Api to IdentityServer (AuthorizationController in VTS.Backend.Api project)
                    // A Username and password of a registered user in IdentityServer will be supplied
                    // That's why GrantTypes.ResourceOwnerPassword is used
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role",
                        "app.vts.frontend.read",
                        "app.vts.frontend.write"
                    }
                }
            };
        }
    }
}
