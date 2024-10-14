using Homemap.Domain.Core;
using System.Linq.Expressions;

namespace Homemap.ApplicationCore.Interfaces.Repositories;
public interface IReceiverRepository : IRepository {

    Task<Receiver> AddAsync(Receiver entity);

    Task<IReadOnlyList<Receiver>> FindAllAsync();

    Task<Receiver?> FindByIdAsync(int id);

    Task<Receiver?> FindByConditionAsync(Expression<Func<Receiver, bool>> predicate);

    void Remove(Receiver entity);

    void Update(Receiver entity);

    Task<IReadOnlyList<Receiver>> FindByParentAsync(int parentId);

    Task<bool> ProjectExistsAsync(int projectId);


}
