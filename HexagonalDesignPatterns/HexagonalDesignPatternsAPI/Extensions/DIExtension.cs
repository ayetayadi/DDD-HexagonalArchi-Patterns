using HexagonalDesignPatterns.Application.Ports.Driven;
using HexagonalDesignPatterns.Application.Ports.Driving;
using HexagonalDesignPatterns.Application.Services;
using HexagonalDesignPatterns.Domain.Factories;
using HexagonalDesignPatterns.Domain.Strategies;
using HexagonalDesignPatterns.Infrastructure.Data;
using HexagonalDesignPatterns.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HexagonalDesignPatterns.API.Extensions
{
    public static class DIExtension
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<AppDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ISmartphoneService, SmartphoneService>()
                .AddScoped<IPricingStrategyFactory, PricingStrategyFactory>()
                .AddScoped<IPricingStrategy, StandardPricingStrategy>();
        }

        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ISmartphoneRepository, SmartphoneRepository>();
        }
    }
}
