

using Homemap.ApplicationCore.Models;
using Homemap.Domain.Common;
using Homemap.Domain.Core;
using System.Linq.Expressions;

namespace Homemap.ApplicationCore.Interfaces.Repositories;
public interface IReceiverRepository : IRepository {
    // Adds a new receiver
    Task<Receiver> AddAsync(Receiver entity);

    // Retrieves all receivers
    Task<IReadOnlyList<Receiver>> FindAllAsync();

    // Retrieves a receiver by its ID
    Task<Receiver?> FindByIdAsync(int id);

    // Retrieves a receiver by a specific condition
    Task<Receiver?> FindByConditionAsync(Expression<Func<Receiver, bool>> predicate);

    // Removes a receiver
    void Remove(Receiver entity);

    // Updates a receiver
    void Update(Receiver entity);

    // Finds receivers by the parent project ID
    Task<IReadOnlyList<Receiver>> FindByParentAsync(int parentId);
   
}
