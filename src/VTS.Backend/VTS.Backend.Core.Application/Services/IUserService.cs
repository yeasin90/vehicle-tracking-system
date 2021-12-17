using VTS.Backend.Core.Application.Models;

namespace VTS.Backend.Core.Application.Services
{
    public interface IUserService
    {
        VtsUser GetCurrentUser();
    }
}
