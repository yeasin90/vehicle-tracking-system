using Geocoding;
using Geocoding.Google;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTS.Backend.Infrastructure.GoogleMapService.Settings;

namespace VTS.Backend.Infrastructure.GoogleMapService
{
    // Nuget reference: https://github.com/chadly/Geocoding.net
    public class VtsGoogleMapService : IVtsGoogleMapService
    {
        private readonly GoogleMapSettings _gmapSettings;
        public VtsGoogleMapService(IOptions<GoogleMapSettings> gmapSettings)
        {
            _gmapSettings = gmapSettings.Value;
        }

        public async Task<string> GetLocationName(double latitude, double longitude)
        {
            try
            {
                IGeocoder geocoder = new GoogleGeocoder() { ApiKey = _gmapSettings.ApiKey };
                IEnumerable<Address> addresses = await geocoder.ReverseGeocodeAsync(latitude, longitude);
                return addresses.FirstOrDefault().FormattedAddress;
            }
            catch(Exception ex)
            {
                // Hungry for logging. Can be configured later.
                return string.Empty;
            }   
        }
    }
}
