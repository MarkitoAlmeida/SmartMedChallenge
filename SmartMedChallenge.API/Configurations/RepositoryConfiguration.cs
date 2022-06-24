using Microsoft.Extensions.DependencyInjection;
using SmartMedChallenge.Application.Interfaces.Repositories;
using SmartMedChallenge.Data.Repositories;

namespace SmartMedChallenge.API.Configurations
{
    public static class RepositoryConfiguration
    {
        public static IServiceCollection AddRepositoryConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IMedicationRepository, MedicationRepository>();

            return services;
        }
    }
}
