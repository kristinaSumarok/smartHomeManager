using AutoMapper;
using Homemap.ApplicationCore.Interfaces.Repositories;
using Homemap.ApplicationCore.Models;
using Homemap.ApplicationCore.Services;
using Homemap.Domain.Core;

public class ReceiverService : BaseService<Receiver, ReceiverDto> {

    private readonly ISubEntityRepository<Receiver> _repository;

    public ReceiverService(IMapper mapper, ISubEntityRepository<Receiver> repository) : base(mapper, repository) {
        _repository = repository;
    }

    public async Task<IReadOnlyList<ReceiverDto>> GetReceiversByProjectAsync(int projectId) {
        var receivers = await _repository.FindByParentAsync(projectId);
        return _mapper.Map<IReadOnlyList<ReceiverDto>>(receivers);
    }

}