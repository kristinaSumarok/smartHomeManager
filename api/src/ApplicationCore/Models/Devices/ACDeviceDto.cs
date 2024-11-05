using Homemap.ApplicationCore.Constants;
using System.Text.Json.Serialization;

namespace Homemap.ApplicationCore.Models.Devices
{
    // the reason we need to add this attribute here as well
    //  https://stackoverflow.com/a/75751184
    [JsonDerivedType(typeof(ACDeviceDto), DeviceConstants.AC)]
    public record ACDeviceDto : DeviceDto
    {
    }
}
