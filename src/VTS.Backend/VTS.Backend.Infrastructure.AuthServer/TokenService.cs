using IdentityModel.Client;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
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
        private readonly DiscoveryDocumentResponse _discoveryDocument;
        private readonly HttpClient _httpClient;
        private readonly AuthorizationServerSettings _authorizationServer;

        public TokenService(HttpClient httpClient, IOptions<AuthorizationServerSettings> authorizationServer)
        {
            _authorizationServer = authorizationServer.Value;
            _httpClient = httpClient;
            _discoveryDocument = httpClient.GetDiscoveryDocumentAsync(
                $"{_authorizationServer.Host}/{Oidc.DiscoveryConfiguration}").Result;
        }

        public async Task<JObject> GetJwtTokenAsync(LoginModel model)
        {
            var tokenResponse = await _httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest()
            {
                Address = _discoveryDocument.TokenEndpoint,
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
