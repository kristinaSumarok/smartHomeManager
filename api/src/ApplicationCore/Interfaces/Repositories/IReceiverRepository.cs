using Homemap.Domain.Core;
using System.Linq.Expressions;

namespace Homemap.ApplicationCore.Interfaces.Repositories;
public interface IReceiverRepository : ICrudRepository<Receiver> {

    Task<IReadOnlyList<Receiver>> FindAllByProjectId(int projectId);
}
