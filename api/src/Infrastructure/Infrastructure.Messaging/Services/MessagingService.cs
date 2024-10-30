using Homemap.ApplicationCore.Interfaces.Services;
using Infrastructure.Messaging.Models;
using MQTTnet;
using MQTTnet.Formatter;
using MQTTnet.Packets;
using System.Buffers;
using System.Collections.Concurrent;
using System.Text.Json;

namespace Infrastructure.Messaging.Services
{
    internal class MessagingService<T> : IMessagingService<T>
    {
        public ConcurrentQueue<T> ReceivedMessages { get; } = new ConcurrentQueue<T>();

        protected readonly IMqttClient _mqttClient;

        private readonly MqttClientOptions _mqttClientOptions;

        public MessagingService(MessagingServiceOptions options)
        {
            var mqttFactory = new MqttClientFactory();
            IMqttClient mqttClient = mqttFactory.CreateMqttClient();

            MqttClientOptions mqttClientOptions = new MqttClientOptionsBuilder()
                .WithConnectionUri(options.ConnectionUri)
                .WithProtocolVersion(MqttProtocolVersion.V500)
                .WithClientId("homemap-api/" + Guid.NewGuid().ToString())
                .WithCleanSession()
                .Build();

            _mqttClient = mqttClient;
            _mqttClientOptions = mqttClientOptions;

            // register events
            _mqttClient.ApplicationMessageReceivedAsync += MqttClient_ApplicationMessageReceivedAsync;
        }

        public async Task ConnectAsync()
        {
            await _mqttClient.ConnectAsync(_mqttClientOptions, CancellationToken.None);

            // This will throw an exception if the server does not reply
            await _mqttClient.PingAsync(CancellationToken.None);
        }

        public async Task DisconnectAsync()
        {
            await _mqttClient.DisconnectAsync(MqttClientDisconnectOptionsReason.NormalDisconnection);
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
