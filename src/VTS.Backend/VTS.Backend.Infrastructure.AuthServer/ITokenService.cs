using IdentityModel.Client;
using System.Threading.Tasks;

namespace VTS.Backend.Infrastructure.AuthServer
{
    public interface ITokenService
    {
        Task<TokenResponse> GetJwtTokenAsync(string username, string password);
    }
}
