using HexaArchi.Application.Mappings;
using HexaArchi.Application.Ports.Driven;
using HexaArchi.Application.Ports.Driving;
using HexaArchi.Application.Services;
using HexaArchi.Infrastructure.Data;
using HexaArchi.Infrastructure.Messaging.Publisher;
using HexaArchi.Infrastructure.Repositories;
using HexaArchi.SharedKarnel.Configuration;
using Microsoft.EntityFrameworkCore;

namespace HexaArchi.API.Extensions
{
    public static class DIExtension
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }


        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            return services.AddScoped<IAuthorRepository, AuthorRepository>()
                   .AddScoped<IArticleRepository, ArticleRepository>()
                   .AddScoped<IAuthorService, AuthorService>()
                   .AddScoped<IArticleService, ArticleService>()
                   .AddScoped<IWritingService, WritingService>();
        }

        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            return services.AddAutoMapper(typeof(AuthorMappingProfile).Assembly)
                .AddAutoMapper(typeof(ArticleMappingProfile).Assembly)
                .AddAutoMapper(typeof(WritingMappingProfile).Assembly);

        }

        public static IServiceCollection AddRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            return services.Configure<RabbitMQSettings>(configuration.GetSection("RabbitMQSettings"))
                 .AddScoped<IMessagePublisher, RabbitMqMessagePublisher>();

        }
    }
}
