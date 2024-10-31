using Homemap.ApplicationCore.Constants;
using Homemap.ApplicationCore.Models.DeviceStates;
using System.Text.Json.Serialization;

namespace Homemap.ApplicationCore.Models
{
    [JsonDerivedType(typeof(SocketDeviceStateDto), DeviceStateConstants.SOCKET)]
    [JsonDerivedType(typeof(ACDeviceStateDto), DeviceStateConstants.AC)]
    [JsonDerivedType(typeof(ThermostatDeviceStateDto), DeviceStateConstants.THERMOSTAT)]
    [JsonDerivedType(typeof(LightbulbDeviceStateDto), DeviceStateConstants.LIGHTBULB)]
    public abstract record DeviceStateDto(bool IsTurnedOn);
}
