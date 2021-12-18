using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using VTS.IdentityServer.Extensions;
using VTS.IdentityServer.IdentityConfiguration;
using VTS.IdentityServer.Settings;

namespace VTS.IdentityServer
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _configuration = configuration;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.CorsConfigurations(_configuration);

            // in-memory configurations for development purpose.
            // should be replaced with actual database in production
            var identityServiceBuilder = services.AddIdentityServer()
                .AddInMemoryClients(Clients.Get())
                .AddInMemoryIdentityResources(Resources.GetIdentityResources())
                .AddInMemoryApiResources(Resources.GetApiResources())
                .AddInMemoryApiScopes(Scopes.GetApiScopes())
                .AddTestUsers(Users.Get());

            // Only for developemnt. Real certificate needs to be used on Production
            if (_env.IsDevelopment())
            {
                identityServiceBuilder.AddDeveloperSigningCredential();
            }
        }

        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var corsSettings = app.ApplicationServices.GetService<IOptions<CorsSettings>>();

            app.UseRouting();
            app.UseCors(corsSettings.Value.Name);
            app.UseIdentityServer();
            app.UseEndpoints(endpoints =>
            {
                // This default /index.html was added by IdentityServer4 nuget
                // Instead of adding a pages, just added a message to notify server is up
                endpoints.MapGet("/index.html", async context =>
                {
                    await context.Response.WriteAsync("Auth server up and running!");
                });
            });
        }
    }
}
