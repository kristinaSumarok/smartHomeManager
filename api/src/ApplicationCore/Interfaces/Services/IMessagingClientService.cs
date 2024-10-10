namespace Homemap.ApplicationCore.Interfaces.Services
{
    public interface IMessagingClientService
    {
        Task ConnectAsync();

        Task DisconnectAsync();
    }
}
