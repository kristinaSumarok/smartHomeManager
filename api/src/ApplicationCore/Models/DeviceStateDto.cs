using Homemap.ApplicationCore.Models.DeviceState;
using System.Text.Json.Serialization;

namespace Homemap.ApplicationCore.Models
{
    [JsonDerivedType(typeof(SocketDeviceStateDto), "socket")]
    [JsonDerivedType(typeof(ACDeviceStateDto), "ac")]
    [JsonDerivedType(typeof(ThermostatDeviceStateDto), "thermostat")]
    [JsonDerivedType(typeof(LightbulbDeviceStateDto), "lightbulb")]
    public abstract record DeviceStateDto(bool IsTurnedOn);
}
