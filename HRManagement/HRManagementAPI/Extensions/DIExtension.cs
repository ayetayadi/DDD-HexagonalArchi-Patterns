using HRManagement.API.Mappings;
using HRManagement.API.Services;
using HRManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.API.Extensions
{
    public static class DIExtension
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            return services.AddScoped<UserServiceCRUD>()
                .AddScoped<DepartmentServiceCRUD>();


        }

        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            return services.AddAutoMapper(typeof(UserMappingProfile).Assembly)
                .AddAutoMapper(typeof(DepartmentMappingProfile).Assembly);
        } 
    }
}
