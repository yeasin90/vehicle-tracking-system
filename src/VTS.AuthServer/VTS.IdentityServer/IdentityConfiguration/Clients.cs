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
                    ClientSecrets = new List<Secret> {new Secret("VTS.Backend.Api.Secret".Sha256())},
                    AllowedScopes = new List<string> { "app.api.vts.read", "app.api.vts.write" }
                },
                new Client
                {
                    ClientId = "VTS.Frontend",
                    ClientName = "VTS.Frontend",
                    ClientSecrets = new List<Secret> {new Secret("VTS.Frontend.Secret".Sha256())},
                    AccessTokenType = AccessTokenType.Jwt,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role",
                        "app.api.vts.read",
                        "app.api.vts.write"
                    }
                }
            };
        }
    }
}
