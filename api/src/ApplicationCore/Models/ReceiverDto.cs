using Homemap.ApplicationCore.Models.Common;

namespace Homemap.ApplicationCore.Models
{
    public record ReceiverDto(
        int Id, string Name,IReadOnlyCollection<DeviceDto> Devices) : EntityDto(Id);
}
