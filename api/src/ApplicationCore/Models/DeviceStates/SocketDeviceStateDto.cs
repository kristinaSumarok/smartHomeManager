using Homemap.ApplicationCore.Constants;
using System.Text.Json.Serialization;

namespace Homemap.ApplicationCore.Models.DeviceStates
{
    [JsonDerivedType(typeof(SocketDeviceStateDto), DeviceStateConstants.SOCKET)]
    public record SocketDeviceStateDto(bool IsTurnedOn) : DeviceStateDto(IsTurnedOn);
}
