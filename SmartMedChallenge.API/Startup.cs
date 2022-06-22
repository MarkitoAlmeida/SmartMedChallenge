using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SmartMedChallenge.API.Configurations;

namespace SmartMedChallenge.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                );
            });

            // Application Context
            services.AddSmartMedChallengeContext(Configuration);

            // AutoMapper Configuration
            services.AddAutoMapperConfiguration();

            services.AddControllers();

            // Swagger Configuration
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                                   {
                                        Title = "API - SmartMedChallenge",
                                        Version = "v1",
                                        Description = "This API was developed as a technical assessment for Smart Med B.V. recruitment process.",
                                        Contact = new OpenApiContact() { Name = "Marcos Paulo Figueiredo de Almeida", Email = "mpalmeida88@gmail.com"}
                                    });
            });

            // Resolve Dependencies
            services.AddRepositoryConfiguration();
            services.AddServiceConfiguration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartMedChallenge.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
