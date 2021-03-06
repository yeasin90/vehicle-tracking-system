using IdentityModel;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace VTS.IdentityServer.IdentityConfiguration
{
    public class Users
    {
        public static List<TestUser> Get()
        {
            return new List<TestUser> 
            {
                new TestUser 
                {
                    SubjectId = new Guid("c81c4032-859e-4e3c-817d-541163929df5").ToString(),
                    Username = "user1",
                    Password = "userpassword1",
                    Claims = new List<Claim> 
                    {
                        new Claim(JwtClaimTypes.Role, "User")
                    }
                },
                new TestUser
                {
                    SubjectId = new Guid("8e29eb61-c78c-4f24-a040-bcd822991502").ToString(),
                    Username = "user2",
                    Password = "userpassword2",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Role, "User")
                    }
                },
                new TestUser
                {
                    SubjectId = new Guid("15fcb5c0-a096-41c6-8e93-4ecd81c20b4e").ToString(),
                    Username = "admin1",
                    Password = "adminpassword1",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Role, "Admin")
                    }
                }
            };
        }
    }
}
