using Homemap.ApplicationCore.Constants;
using Homemap.ApplicationCore.Models.Common;
using Homemap.ApplicationCore.Models.Devices;
using System.Text.Json.Serialization;

namespace Homemap.ApplicationCore.Models
{
    [JsonDerivedType(typeof(SocketDeviceDto), DeviceConstants.SOCKET)]
    [JsonDerivedType(typeof(ACDeviceDto), DeviceConstants.AC)]
    [JsonDerivedType(typeof(ThermostatDeviceDto), DeviceConstants.THERMOSTAT)]
    [JsonDerivedType(typeof(LightbulbDeviceDto), DeviceConstants.LIGHTBULB)]
    public abstract record DeviceDto(int Id, string Name) : EntityDto(Id);
}
