using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace VTS.IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
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
