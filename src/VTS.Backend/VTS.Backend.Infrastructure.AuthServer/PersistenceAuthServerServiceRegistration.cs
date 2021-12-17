using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace VTS.Backend.Infrastructure.AuthServer
{
    public static class PersistenceAuthServerServiceRegistration
    {
        public static IServiceCollection AddPersistenceAuthServerServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        // base-address of identityserver
                        options.Authority = configuration["AuthenticationServer:Host"];

                        // if you are using API resources, you can specify the name here
                        options.Audience = configuration["AuthenticationServer:Audience"];

                        // Extra check
                        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidIssuer = configuration["AuthenticationServer:Host"],
                            ValidAudience = configuration["AuthenticationServer:Audience"]
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
