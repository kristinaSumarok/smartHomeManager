using Homemap.ApplicationCore.Models.Common;

namespace Homemap.ApplicationCore.Models
{
    public record DeviceDto(int Id, string Name, string Type) : EntityDto(Id);
}
