using Homemap.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Homemap.Infrastructure.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Receiver> Receivers { get; set; }
    }
}
