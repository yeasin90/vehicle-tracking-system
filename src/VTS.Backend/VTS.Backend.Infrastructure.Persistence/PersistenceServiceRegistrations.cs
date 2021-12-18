using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using VTS.Backend.Core.Application.Contracts;
using VTS.Backend.Infrastructure.Persistence.Repositories;
using VTS.Backend.Infrastructure.Persistence.Settings;

namespace VTS.Backend.Infrastructure.Persistence
{
    public static class PersistenceServiceRegistrations
    {
        public static IServiceCollection AddDatabaseConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SqliteDatabaseSettings>(options => configuration.GetSection("SqliteDatabaseSettings").Bind(options));

            var dbSettings = services.BuildServiceProvider().GetService<IOptions<SqliteDatabaseSettings>>();

            // Used Sqlite for Proof of concept
            // Can be replaced with any centralized relationalt DB or NoSql DB
            services.AddDbContext<VtsDbContext>(options =>
                options.UseSqlite(dbSettings.Value.ConnectionString));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IVehiclePositionRepository, VehiclePositionRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();

            return services;
        }
    }
}
