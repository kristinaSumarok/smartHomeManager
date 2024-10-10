using Homemap.ApplicationCore.Interfaces.Services;
using MQTTnet;
using MQTTnet.Formatter;

namespace Infrastructure.Messaging.Services
{
    internal class MessagingClientService : IMessagingClientService
    {
        public IMqttClient Client { get; }

        private readonly MqttClientOptions _mqttClientOptions;

        public MessagingClientService(string? connectionString)
        {
            var mqttFactory = new MqttClientFactory();
            IMqttClient mqttClient = mqttFactory.CreateMqttClient();

            MqttClientOptions mqttClientOptions = new MqttClientOptionsBuilder()
                .WithConnectionUri(connectionString)
                .WithProtocolVersion(MqttProtocolVersion.V500)
                .WithClientId("homemap-api/" + Guid.NewGuid().ToString())
                .WithCleanSession()
                .Build();

            Client = mqttClient;
            _mqttClientOptions = mqttClientOptions;
        }

        public async Task ConnectAsync()
        {
            await Client.ConnectAsync(_mqttClientOptions, CancellationToken.None);

            // This will throw an exception if the server does not reply
            await Client.PingAsync(CancellationToken.None);
        }

        public async Task DisconnectAsync()
        {
            await Client.DisconnectAsync(MqttClientDisconnectOptionsReason.NormalDisconnection);
        }
    }
}
