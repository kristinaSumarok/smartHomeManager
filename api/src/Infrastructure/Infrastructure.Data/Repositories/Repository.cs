using Homemap.ApplicationCore.Interfaces.Repositories;
using Homemap.Infrastructure.Data.Contexts;

namespace Homemap.Infrastructure.Data.Repositories
{
    internal class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
        }
    }
}
