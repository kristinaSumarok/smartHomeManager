namespace Homemap.ApplicationCore.Models.DeviceState
{
    public record SocketDeviceStateDto(bool IsTurnedOn) : DeviceStateDto(IsTurnedOn);
}
