using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SmartMedChallenge.Application.Mapper;

namespace SmartMedChallenge.API.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            var config = AutoMapperSetup.RegisterMapper();

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
