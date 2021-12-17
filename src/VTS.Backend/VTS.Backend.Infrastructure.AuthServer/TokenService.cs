using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using static VTS.Backend.Infrastructure.AuthServer.OidcConstants;

namespace VTS.Backend.Infrastructure.AuthServer
{
    public class TokenService : ITokenService
    {
        private readonly DiscoveryDocumentResponse _discoveryDocument;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public TokenService(HttpClient httpClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _discoveryDocument = httpClient.GetDiscoveryDocumentAsync(
                $"{configuration["AuthenticationServer:Host"]}/{Oidc.DiscoveryConfiguration}").Result;
        }

        public async Task<TokenResponse> GetJwtTokenAsync(string username, string password)
        {
            var tokenResponse = await _httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest()
            {
                Address = _discoveryDocument.TokenEndpoint,
                ClientId = _configuration["AuthenticationServer:ClientId"],
                ClientSecret = _configuration["AuthenticationServer:ClientSecret"],
                UserName = username,
                Password = password
            });

            return tokenResponse;
        }
    }
}
