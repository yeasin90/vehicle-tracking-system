using IdentityModel.Client;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using VTS.Backend.Infrastructure.AuthServer.Exceptions;
using VTS.Backend.Infrastructure.AuthServer.Models;
using VTS.Backend.Infrastructure.AuthServer.Settings;
using static VTS.Backend.Infrastructure.AuthServer.OidcConstants;

namespace VTS.Backend.Infrastructure.AuthServer
{
    public class TokenService : ITokenService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthorizationServerSettings _authorizationServer;

        public TokenService(HttpClient httpClient, IOptions<AuthorizationServerSettings> authorizationServer)
        {
            _authorizationServer = authorizationServer.Value;
            _httpClient = httpClient;
        }

        // Related to GrantTypes.ResourceOwnerPassword client in IdentityServer
        public async Task<JObject> GetJwtTokenAsync(LoginModel model)
        {
            Console.WriteLine($"{_authorizationServer.Host}/{Oidc.DiscoveryConfiguration}");

            var tokenResponse = await _httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest()
            {
                Address = $"{_authorizationServer.Host}/{Oidc.Token}",
                ClientId = _authorizationServer.FrontEndClientId,
                ClientSecret = _authorizationServer.FrotEndClientSecret,
                UserName = model.Username,
                Password = model.Password
            });

            if (tokenResponse.IsError)
            {
                throw new AuthServerException($"Failed to get token. {tokenResponse.Error}");
            }

            return tokenResponse.Json;
        }
    }
}
