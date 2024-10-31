using Homemap.ApplicationCore.Constants;
using System.Text.Json.Serialization;

namespace Homemap.ApplicationCore.Models.Devices
{
    [JsonDerivedType(typeof(SocketDeviceDto), DeviceConstants.SOCKET)]
    public record SocketDeviceDto(int Id, string Name) : DeviceDto(Id, Name);
}
