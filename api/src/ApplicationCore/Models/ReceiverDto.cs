using Homemap.ApplicationCore.Models.Common;

namespace Homemap.ApplicationCore.Models
{
    public record ReceiverDto : AuditableEntityDto
    {
        public required string Name { get; init; }

        public IReadOnlyCollection<DeviceDto> Devices { get; init; } = [];
    }
}
