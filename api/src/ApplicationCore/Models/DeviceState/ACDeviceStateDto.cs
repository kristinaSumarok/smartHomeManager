namespace Homemap.ApplicationCore.Models.DeviceState
{
    public record ACDeviceStateDto(bool IsTurnedOn, decimal Temperature) : DeviceStateDto(IsTurnedOn);
}
