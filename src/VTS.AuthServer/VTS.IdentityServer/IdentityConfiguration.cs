using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace VTS.IdentityServer
{
    public class IdentityConfiguration
    {
        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    Username = "admin1",
                    Password = "admin1",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Id, new Guid("ff5c4eba-fcfa-4c79-9950-14e83b9afa75").ToString()),
                        new Claim(JwtClaimTypes.Role, RoleTypes.User.ToString())
                    }
                },
                new TestUser
                {
                    Username = "user1",
                    Password = "user1",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Id, new Guid("ff5c4eba-fcfa-4c79-9950-14e83b9afa75").ToString()),
                        new Claim(JwtClaimTypes.Role, RoleTypes.User.ToString())
                    }
                }
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("myApi.read"),
                new ApiScope("myApi.write"),
            };
        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("myApi")
                {
                    Scopes = new List<string>{ "myApi.read","myApi.write" },
                    ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "cwm.client",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "myApi.read" }
                },
            };
    }
}
