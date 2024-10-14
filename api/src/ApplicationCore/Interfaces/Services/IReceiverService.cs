using ErrorOr;

using Homemap.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homemap.ApplicationCore.Interfaces.Services {
    public interface IReceiverService{
        Task<ErrorOr<ReceiverDto>> GetByIdAsync(int projectId,int id);

        Task<IReadOnlyList<ReceiverDto>> GetAllAsync(int projectId);

        Task<ErrorOr<ReceiverDto>> CreateAsync(int projectId, ReceiverDto dto);

        Task<ErrorOr<ReceiverDto>> UpdateAsync(int projectId, int id, ReceiverDto dto);

        Task<ErrorOr<Deleted>> DeleteAsync(int projectId, int id);
    }
}
