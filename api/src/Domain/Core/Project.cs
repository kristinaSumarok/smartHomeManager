using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Core
{
    public class Project : AuditableEntity
    {
        [Required]
        public string Name { get; set; } = null!;

        public ICollection<Receiver> Receivers { get; } = new List<Receiver>();
    }
}
