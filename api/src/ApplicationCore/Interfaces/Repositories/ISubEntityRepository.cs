

using Homemap.Domain.Common;

namespace Homemap.ApplicationCore.Interfaces.Repositories;
public interface ISubEntityRepository<TEntity> : ICrudRepository<TEntity>
    where TEntity : Homemap.Domain.Common.Entity {
    Task<IReadOnlyList<TEntity>> FindByParentAsync(int userId);
}
