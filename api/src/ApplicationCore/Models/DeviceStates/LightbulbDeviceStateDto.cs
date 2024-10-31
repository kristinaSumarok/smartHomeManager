using System.Text.Json.Serialization;
using Homemap.ApplicationCore.Constants;

namespace Homemap.ApplicationCore.Models.DeviceStates
{
    [JsonDerivedType(typeof(LightbulbDeviceStateDto), DeviceStateConstants.LIGHTBULB)]
    public record LightbulbDeviceStateDto(bool IsTurnedOn, int Temperature, int Brightness) : DeviceStateDto(IsTurnedOn);
}
