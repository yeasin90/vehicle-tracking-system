using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VTS.Backend.Core.Application.Settings;

namespace VTS.Backend.Core.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SqliteDatabaseSettings>(options => configuration.GetSection(nameof(SqliteDatabaseSettings)));

            return services;
        }
    }
}