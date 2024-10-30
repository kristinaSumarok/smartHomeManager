using Homemap.ApplicationCore.Models.Messaging;
using System.Collections.Concurrent;

namespace Homemap.ApplicationCore.Interfaces.Services
{
    public interface IMessagingService<T>
    {
        ConcurrentQueue<T> ReceivedMessages { get; }

        Task ConnectAsync();

        Task DisconnectAsync();

        Task PublishAsync(string topic, T message, MessagingServicePublishOptions options);

        Task SubscribeAsync(string topic);
    }
}
