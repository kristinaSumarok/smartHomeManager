using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Core
{
    public class Device : AuditableEntity
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public DeviceType DeviceType { get; set; }

        [Required]
        public int ReceiverId { get; set; }

        [Required]
        public Receiver Receiver { get; set; } = null!;
    }
}
