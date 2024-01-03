using Microsoft.Extensions.DependencyInjection;
using StarWars_Core.Interface;
using StarWars_Core.Service;

namespace StarWars_Core.Common
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Add data access layer services
            services.AddScoped<IPeopleService, PeopleService>();

            // Add business logic layer services
            return services;
        }
    }
}
