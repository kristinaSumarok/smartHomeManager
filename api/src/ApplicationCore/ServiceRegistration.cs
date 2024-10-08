using Homemap.ApplicationCore.Interfaces.Services;
using Homemap.ApplicationCore.Mappings;
using Homemap.ApplicationCore.Models;
using Homemap.ApplicationCore.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Homemap.ApplicationCore
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProjectProfile).Assembly);
            services.AddAutoMapper(typeof(ReceiverProfile).Assembly);

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IService<ProjectDto>, ProjectService>();
            services.AddScoped<IService<ReceiverDto>, ReceiverService>();

            return services;
        }
    }
}
