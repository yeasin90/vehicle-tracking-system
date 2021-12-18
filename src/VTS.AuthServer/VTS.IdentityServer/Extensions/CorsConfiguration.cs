using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using VTS.IdentityServer.Settings;

namespace VTS.IdentityServer.Extensions
{
    public static class CorsConfiguration
    {
        public static IServiceCollection CorsConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CorsSettings>(options => configuration.GetSection("CorsSettings").Bind(options));

            var corsSettings = services.BuildServiceProvider().GetService<IOptions<CorsSettings>>();

            services.AddCors(options =>
            {
                options.AddPolicy(corsSettings.Value.Name,
                    builder => builder.WithOrigins(corsSettings.Value.AllowedHosts.ToArray())
                .AllowAnyHeader()
                .AllowAnyMethod());
            });

            return services;
        }
    }
}
