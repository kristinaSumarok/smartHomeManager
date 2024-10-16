using Homemap.Domain.Core;

namespace Homemap.ApplicationCore.Interfaces.Repositories;
public interface IReceiverRepository : ICrudRepository<Receiver>
{

    Task<IReadOnlyList<Receiver>> FindAllByProjectId(int projectId);
}
