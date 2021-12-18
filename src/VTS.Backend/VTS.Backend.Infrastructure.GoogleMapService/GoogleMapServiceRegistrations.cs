using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VTS.Backend.Infrastructure.GoogleMapService.Settings;

namespace VTS.Backend.Infrastructure.GoogleMapService
{
    public static class GoogleMapServiceRegistrations
    {
        public static IServiceCollection AddGoogleMapServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<GoogleMapSettings>(options => configuration.GetSection("GoogleMapSettings").Bind(options));

            services.AddScoped<IVtsGoogleMapService, VtsGoogleMapService>();

            return services;
        }
    }
}
