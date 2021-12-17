using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace VTS.Backend.Infrastructure.AuthServer
{
    public class TokenService : ITokenService
    {
        private readonly DiscoveryDocumentResponse _discoveryDocument;
        private readonly HttpClient _httpClient;

        public TokenService(HttpClient httpClient, IConfiguration Configuration)
        {
            _httpClient = httpClient;
            _discoveryDocument = httpClient.GetDiscoveryDocumentAsync(
                "http://localhost:5000/.well-known/openid-configuration").Result;
        }

        public async Task<string> GetToken()
        {
            var tokenResponse = await _httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest()
            {
                Address = _discoveryDocument.TokenEndpoint,
                ClientId = "oidcMVCApp",
                ClientSecret = "ProCodeGuide",
                UserName = "procoder",
                Password = "password"

            });

            return tokenResponse.AccessToken;
        }
    }
}
