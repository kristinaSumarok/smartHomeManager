using Homemap.ApplicationCore.Models.Common;

namespace Homemap.ApplicationCore.Models
{
    public record ProjectDto : AuditableEntityDto
    {
        public required string Name { get; init; }
    }
}
