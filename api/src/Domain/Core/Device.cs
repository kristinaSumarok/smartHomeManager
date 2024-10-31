using Homemap.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Homemap.Domain.Core
{
    public abstract class Device : AuditableEntity
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public int ReceiverId { get; set; }

        [Required]
        public virtual Receiver Receiver { get; set; } = null!;
    }
}
