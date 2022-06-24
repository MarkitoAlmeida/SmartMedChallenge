using Microsoft.Extensions.DependencyInjection;
using SmartMedChallenge.Application.Interfaces;
using SmartMedChallenge.Application.Interfaces.Services;
using SmartMedChallenge.Application.Notifications;
using SmartMedChallenge.Application.Services;

namespace SmartMedChallenge.API.Configurations
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddServiceConfiguration(this IServiceCollection services)
        {
            // Notificator
            services.AddScoped<INotificator, Notificator>();

            // API Services
            services.AddScoped<IMedicationService, MedicationService>();

            return services;
        }
    }
}
