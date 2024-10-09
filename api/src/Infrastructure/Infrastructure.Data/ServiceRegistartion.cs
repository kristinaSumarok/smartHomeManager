using Homemap.ApplicationCore.Interfaces.Repositories;
using Homemap.Infrastructure.Data.Contexts;
using Homemap.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Homemap.Infrastructure.Data
{
    public static class ServiceRegistartion
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options
                .UseLazyLoadingProxies()
                .UseSqlite(
                    configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                ));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICrudRepository<>), typeof(CrudRepository<>));
            services.AddScoped(typeof(ISubEntityRepository<>), typeof(SubEntityRepository<>));

            return services;
        }
    }
}
