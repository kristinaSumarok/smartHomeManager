using Homemap.ApplicationCore.Interfaces.Repositories;
using Homemap.Domain.Core;
using Homemap.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Homemap.Infrastructure.Data.Repositories
{
    internal class ReceiverRepository : CrudRepository<Receiver>, IReceiverRepository
    {
        private readonly ApplicationDbContext _context;

        public ReceiverRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Receiver>> FindAllByProjectId(int projectId)
        {
            return await _context.Receivers
                .Where(e => e.ProjectId == projectId)
                .ToListAsync();
        }
    }
}
