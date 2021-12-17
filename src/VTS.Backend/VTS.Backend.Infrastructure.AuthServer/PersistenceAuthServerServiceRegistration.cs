using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VTS.Backend.Infrastructure.AuthServer
{
    public static class PersistenceAuthServerServiceRegistration
    {
        public static IServiceCollection AddPersistenceAuthServerServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
