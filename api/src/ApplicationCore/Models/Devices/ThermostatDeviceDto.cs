using Homemap.ApplicationCore.Constants;
using System.Text.Json.Serialization;

namespace Homemap.ApplicationCore.Models.Devices
{
    [JsonDerivedType(typeof(ThermostatDeviceDto), DeviceConstants.THERMOSTAT)]
    public record ThermostatDeviceDto : DeviceDto
    {
    }
}
