using Microsoft.Extensions.DependencyInjection;
using SmartMedChallenge.Application.Interfaces.Services;
using SmartMedChallenge.Application.Services;

namespace SmartMedChallenge.API.Configurations
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IMedicationService, MedicationService>();

            return services;
        }
    }
}
