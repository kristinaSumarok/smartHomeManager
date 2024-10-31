namespace Homemap.ApplicationCore.Models.Common
{
    public record AuditableEntityDto : EntityDto
    {
        public DateTime CreatedAt { get; init; }

        public DateTime LastModifiedAt { get; init; }
    }
}
