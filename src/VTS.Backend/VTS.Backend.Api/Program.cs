using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using VTS.Backend.Infrastructure.Persistence;

namespace VTS.Backend.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<VtsDbContext>();
                db.Database.Migrate();
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration(appConfig =>
                    {
                        appConfig.SetBasePath(Environment.CurrentDirectory);
                        appConfig.AddJsonFile("appsettings.json", false, true);
                        appConfig.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", false, true);
                        appConfig.AddEnvironmentVariables();
                        appConfig.Build();
                    });

                    webBuilder.UseStartup<Startup>();
                });
    }
}
