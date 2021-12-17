using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using VTS.Backend.Infrastructure.AuthServer.Settings;

namespace VTS.Backend.Infrastructure.AuthServer
{
    public static class PersistenceAuthServerServiceRegistration
    {
        public static IServiceCollection AddPersistenceAuthServerServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthorizationServerSettings>(options => configuration.GetSection("AuthorizationServerSettings").Bind(options));

            var authServerSettings = services.BuildServiceProvider().GetService<IOptions<AuthorizationServerSettings>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
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

                        options.Events = new JwtBearerEvents()
                        {
                            OnAuthenticationFailed = context =>
                            {
                                return Task.CompletedTask;
                            },
                            OnTokenValidated = context =>
                            {
                                return Task.CompletedTask;
                            },
                            OnMessageReceived = context =>
                            {
                                return Task.CompletedTask;
                            },
                            OnChallenge = context =>
                            {
                                return Task.CompletedTask;
                            },
                            OnForbidden = context =>
                            {
                                return Task.CompletedTask;
                            },
                        };
                    });

            return services;
        }
    }
}
