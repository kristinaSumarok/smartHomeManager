using Homemap.ApplicationCore.Interfaces.Services;
using Infrastructure.Messaging.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Messaging
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddMessagingService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMessagingClientService, MessagingClientService>(_ =>
                new MessagingClientService(configuration.GetConnectionString("MqttDefaultConnection"))
            );
            services.AddSingleton(typeof(IMessagingService<>), typeof(MessagingService<>));

            return services;
        }
    }
}
