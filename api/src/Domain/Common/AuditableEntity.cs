using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homemap.Domain.Common
{
    public abstract class AuditableEntity : Entity
    {
        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime LastModifiedAt { get; set; }
    }
}
