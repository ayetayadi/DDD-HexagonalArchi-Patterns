using BookFetcher.Application.Factory;
using BookFetcher.Application.Ports.Driven;
using BookFetcher.Application.Ports.Driving;
using BookFetcher.Application.Services;
using BookFetcher.Infrastructure;
using BookFetcher.Infrastructure.Adapters;
using BookFetcher.Infrastructure.Repositories;
using BookFetcher.Infrastructure.ThirdParties;
using Microsoft.EntityFrameworkCore;

namespace BookFetcher.API.Extensions
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
            services.AddScoped<IBookService, BookService>()
                .AddScoped<IBookFactory, BookFactory>()
                .AddTransient<ThirdPartyPaymentGateway>()
                 .AddTransient<IPaymentProcessor, PaymentProcessorAdapter>();
        }

        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
