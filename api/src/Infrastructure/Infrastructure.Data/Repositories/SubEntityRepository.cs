using Homemap.ApplicationCore.Interfaces.Repositories;
using Homemap.Domain.Common;
using Homemap.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Homemap.Infrastructure.Data.Repositories {
    internal class SubEntityRepository<T> : CrudRepository<T>, ISubEntityRepository<T> where T : Entity {

        private readonly DbSet<T> _entities;
        public SubEntityRepository(ApplicationDbContext context) : base(context) {
            _entities = context.Set<T>();
        }

        public Task<IReadOnlyList<T>> FindByParentAsync(int userId) {
            throw new NotImplementedException();
        }
    }
}
