using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using VTS.Backend.Infrastructure.AuthServer.Settings;

namespace VTS.Backend.Infrastructure.AuthServer
{
    public static class PersistenceAuthServerServiceRegistration
    {
        public static IServiceCollection AddAuthServerConfigurations(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.Configure<AuthorizationServerSettings>(options => configuration.GetSection("AuthorizationServerSettings").Bind(options));

            var authServerSettings = services.BuildServiceProvider().GetService<IOptions<AuthorizationServerSettings>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        if(env.IsDevelopment())
                        {
                            // For Development, Https is disabled
                            options.RequireHttpsMetadata = false;
                        }

                        // base-address of identityserver
                        options.Authority = authServerSettings.Value.Host;

                        // if you are using API resources, you can specify the name here
                        options.Audience = authServerSettings.Value.Audience;

                        // Extra check
                        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidIssuer = authServerSettings.Value.Host,
                            ValidAudience = authServerSettings.Value.Audience
                        };
                    });

            return services;
        }
    }
}
