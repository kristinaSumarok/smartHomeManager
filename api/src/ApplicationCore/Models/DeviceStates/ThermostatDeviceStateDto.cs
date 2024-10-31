using Homemap.ApplicationCore.Constants;
using System.Text.Json.Serialization;

namespace Homemap.ApplicationCore.Models.DeviceStates
{
    [JsonDerivedType(typeof(ThermostatDeviceStateDto), DeviceStateConstants.THERMOSTAT)]
    public record ThermostatDeviceStateDto(bool IsTurnedOn, decimal Temperature) : DeviceStateDto(IsTurnedOn);
}
