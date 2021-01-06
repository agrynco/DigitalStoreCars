using AutoMapper;
using DAL.Abstract;
using Microsoft.Extensions.Configuration;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Abstract;
using Services.AutoMapper;

namespace DI
{
    public static class DependencyHelper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            
            services.AddDbContext<CarsDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"),
                    sqlOptions => { sqlOptions.EnableRetryOnFailure(); });
            });

            services.AddScoped<ICarModelsRepository, CarModelsRepository>();
            services.AddScoped<ICarModelsService, CarModelsService>();

            return services;
        }
    }
}