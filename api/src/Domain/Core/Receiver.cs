using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Core
{
    public class Receiver : AuditableEntity
    {
        [Required]
        public string Name { get; set; } = null!;

        public int ProjectId { get; set; }

        public Project Project { get; set; } = null!;

        public ICollection<Device> Devices { get; } = new List<Device>();
    }
}
