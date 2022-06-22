using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartMedChallenge.Data.Context;
using System;

namespace SmartMedChallenge.API.Configurations
{
    public static class SmartMedChallengeContextConfiguration
    {
        public static IServiceCollection AddSmartMedChallengeContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = Environment.GetEnvironmentVariable("Development") ?? configuration.GetConnectionString("SmartMedDB");

            services.AddScoped((provider) =>
            {
                return new DbContextOptionsBuilder<SmartMedChallengeContext>()
                    .UseSqlServer(connectionString, options => options.EnableRetryOnFailure())
                    .Options;
            });

            services.AddDbContext<SmartMedChallengeContext>();
            return services;
        }
    }
}
