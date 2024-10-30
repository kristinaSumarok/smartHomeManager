namespace Homemap.ApplicationCore.Models.DeviceState
{
    public record ThermostatDeviceStateDto(bool IsTurnedOn, decimal Temperature) : DeviceStateDto(IsTurnedOn);
}
