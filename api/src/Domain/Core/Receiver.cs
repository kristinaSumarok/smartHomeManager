using Homemap.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Homemap.Domain.Core
{
    public class Receiver : AuditableEntity
    {
        private string _name = null!;

        [Required]
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _name = $"r{Guid.NewGuid()}v_r";
                    return;
                }

                _name = value;
            }
        }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; } = null!;

        public virtual ICollection<Device> Devices { get; } = new List<Device>();
    }
}
