using Homemap.ApplicationCore.Constants;
using System.Text.Json.Serialization;

namespace Homemap.ApplicationCore.Models.DeviceStates
{
    [JsonDerivedType(typeof(ACDeviceStateDto), DeviceStateConstants.AC)]
    public record ACDeviceStateDto(bool IsTurnedOn, decimal Temperature) : DeviceStateDto(IsTurnedOn);
}
