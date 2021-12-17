using IdentityModel.Client;
using System.Threading.Tasks;
using VTS.Backend.Infrastructure.AuthServer.Models;

namespace VTS.Backend.Infrastructure.AuthServer
{
    public interface ITokenService
    {
        Task<TokenResponse> GetJwtTokenAsync(LoginModel model);
    }
}
