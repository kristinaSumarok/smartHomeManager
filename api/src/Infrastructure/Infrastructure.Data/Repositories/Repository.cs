using Homemap.ApplicationCore.Interfaces.Repositories;
using Homemap.Domain.Common;
using Homemap.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Homemap.Infrastructure.Data.Repositories
{
    internal class Repository(ApplicationDbContext context) : IRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<bool> SaveAsync()
        {
            UpdateTimestamps();
            return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
        }

        private void UpdateTimestamps()
        {
            var entries = _context.ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditableEntity && 
                            (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var auditableEntity = (AuditableEntity)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    auditableEntity.CreatedAt = DateTime.UtcNow;
                }

                auditableEntity.LastModifiedAt = DateTime.UtcNow;
            }
        }
    }
}
