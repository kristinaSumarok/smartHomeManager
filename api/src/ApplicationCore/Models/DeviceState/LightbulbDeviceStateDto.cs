namespace Homemap.ApplicationCore.Models.DeviceState
{
    public record LightbulbDeviceStateDto(bool IsTurnedOn, int Temperature, int Brightness) : DeviceStateDto(IsTurnedOn);
}
