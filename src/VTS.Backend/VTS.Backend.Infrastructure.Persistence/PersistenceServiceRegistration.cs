using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace VTS.Backend.Infrastructure.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<VtsDbContext>(options =>
                options.UseSqlite(configuration["SqliteDatabaseSettings:ConnectionString"]));

            return services;
        }
    }
}
