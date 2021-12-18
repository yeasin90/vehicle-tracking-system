using System.Threading.Tasks;

namespace VTS.Backend.Infrastructure.GoogleMapService
{
    public interface IVtsGoogleMapService
    {
        Task<string> GetLocationName(double latitude, double longitude);
    }
}
