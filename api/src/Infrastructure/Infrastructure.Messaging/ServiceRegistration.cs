using Homemap.ApplicationCore.Interfaces.Services;
using Infrastructure.Messaging.Models;
using Infrastructure.Messaging.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Messaging
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddMessagingService(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("MqttDefaultConnection");

            services.AddSingleton(_ => new MessagingServiceOptions
            {
                ConnectionUri = connectionString
            });
            services.AddSingleton(typeof(IMessagingService<>), typeof(MessagingService<>));

            return services;
        }
    }
}
