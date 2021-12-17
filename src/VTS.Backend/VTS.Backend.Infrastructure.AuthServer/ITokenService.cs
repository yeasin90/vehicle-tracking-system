using System.Threading.Tasks;

namespace VTS.Backend.Infrastructure.AuthServer
{
    public interface ITokenService
    {
        Task<string> GetToken();
    }
}
