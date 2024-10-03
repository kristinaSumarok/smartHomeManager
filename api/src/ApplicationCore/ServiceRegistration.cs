using Homemap.ApplicationCore.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Homemap.ApplicationCore
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProjectProfile).Assembly);

            return services;
        }
    }
}
