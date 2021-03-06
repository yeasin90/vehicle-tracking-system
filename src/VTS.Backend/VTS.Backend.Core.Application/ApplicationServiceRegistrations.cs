using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VTS.Backend.Core.Application.Services;

namespace VTS.Backend.Core.Application
{
    public static class ApplicationServiceRegistrations
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
