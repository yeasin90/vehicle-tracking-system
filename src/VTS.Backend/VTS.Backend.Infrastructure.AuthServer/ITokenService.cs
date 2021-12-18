using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using VTS.Backend.Infrastructure.AuthServer.Models;

namespace VTS.Backend.Infrastructure.AuthServer
{
    public interface ITokenService
    {
        Task<JObject> GetJwtTokenAsync(LoginModel model);
    }
}
