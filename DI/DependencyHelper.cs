using Microsoft.Extensions.Configuration;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DI
{
    public static class DependencyHelper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<CarsDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"),
                    sqlOptions => { sqlOptions.EnableRetryOnFailure(); });
            });

            return services;
        }
    }
}