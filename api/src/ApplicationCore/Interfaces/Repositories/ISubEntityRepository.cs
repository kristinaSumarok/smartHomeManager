

using Homemap.Domain.Common;

namespace Homemap.ApplicationCore.Interfaces.Repositories;
public interface ISubEntityRepository<T> : ICrudRepository<T> where T : class {
    Task<IReadOnlyList<T>> FindByParentAsync(int parentId);
}
