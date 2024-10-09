using Homemap.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Homemap.Domain.Core
{
    public class Receiver : AuditableEntity
    {
        [Required]
        public string Name { get; set; } = null!;

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; } = null!;

        public virtual ICollection<Device> Devices { get; } = new List<Device>();
    }
}
