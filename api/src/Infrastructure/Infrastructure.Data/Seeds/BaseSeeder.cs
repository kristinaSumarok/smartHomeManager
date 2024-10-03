using Homemap.Domain.Common;
using Homemap.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Homemap.Infrastructure.Data.Seeds
{
    public abstract class BaseSeeder<T> where T : Entity
    {
        protected readonly DbSet<T> _entities;
        
        protected readonly ApplicationDbContext _context;

        public BaseSeeder(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
    }
}
