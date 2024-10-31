﻿using Homemap.ApplicationCore.Interfaces.Services;
using MQTTnet;
using MQTTnet.Packets;
using System.Buffers;
using System.Collections.Concurrent;
using System.Text.Json;

namespace Infrastructure.Messaging.Services
{
    internal class MessagingService<T> : IMessagingService<T>
    {
        private readonly IMqttClient _mqttClient;

        public ConcurrentQueue<T> ReceivedMessages { get; } = new ConcurrentQueue<T>();

        public MessagingService(MessagingClientService messagingClientService)
        {
            _mqttClient = messagingClientService.Client;

            // register events
            _mqttClient.ApplicationMessageReceivedAsync += MqttClient_ApplicationMessageReceivedAsync;
        }

        private Task MqttClient_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs args)
        {
            //string message = Encoding.UTF8.GetString(args.ApplicationMessage.Payload);
            T? message = JsonSerializer.Deserialize<T>(args.ApplicationMessage.Payload.ToArray());

            if (message is not null)
                ReceivedMessages.Enqueue(message);

            return Task.CompletedTask;
        }

        public async Task PublishAsync(string topic, T message)
        {
            byte[] payload = JsonSerializer.SerializeToUtf8Bytes(message);

            MqttApplicationMessage applicationMessage = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .Build();

            await _mqttClient.PublishAsync(applicationMessage, CancellationToken.None);
        }

        public async Task SubscribeAsync(string topic)
        {
            MqttTopicFilter topicFilter = new MqttTopicFilterBuilder()
                .WithTopic(topic)
                .Build();

            MqttClientSubscribeOptions mqttSubscribeOptions = new MqttClientSubscribeOptionsBuilder()
                .WithTopicFilter(topicFilter)
                .Build();

            await _mqttClient.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);
        }
    }
}