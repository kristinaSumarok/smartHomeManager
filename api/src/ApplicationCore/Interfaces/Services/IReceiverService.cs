using ErrorOr;

using Homemap.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homemap.ApplicationCore.Interfaces.Services {
    public interface IReceiverService : IService<ReceiverDto> {

        Task<ErrorOr<IReadOnlyList<ReceiverDto>>> GetAllAsync(int projectId);

        Task<ErrorOr<ReceiverDto>> CreateAsync(int projectId, ReceiverDto dto);
    }
}
