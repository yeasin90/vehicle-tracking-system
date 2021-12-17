using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using VTS.Backend.Api.Extensions;
using VTS.Backend.Core.Application;
using VTS.Backend.Core.Application.Middleware;
using VTS.Backend.Infrastructure.AuthServer;
using VTS.Backend.Infrastructure.Persistence;

namespace VTS.Backend.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _configuration = configuration;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<ITokenService, TokenService>();

            services.AddHttpContextAccessor();

            services.AddDatabaseConfigurations(_configuration);

            services.AddApplicationServices();

            services.AddAuthServerConfigurations(_configuration, _env);           

            services.AddControllers()
                // To fix reference looping issues on api response
                    .AddNewtonsoftJson(options =>
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });

            services.AddSwaggerConfiguration();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vehicle tracking system API");
                c.RoutePrefix = string.Empty;
            });

            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
