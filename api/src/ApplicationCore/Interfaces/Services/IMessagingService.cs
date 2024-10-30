using System.Collections.Concurrent;

namespace Homemap.ApplicationCore.Interfaces.Services
{
    public interface IMessagingService<T>
    {
        ConcurrentQueue<T> ReceivedMessages { get; }

        Task ConnectAsync();

        Task DisconnectAsync();

        Task PublishAsync(string topic, T message, int QoS = 0, bool retain = false);

        Task SubscribeAsync(string topic);
    }
}
