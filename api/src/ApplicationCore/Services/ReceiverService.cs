using AutoMapper;
using ErrorOr;
using Homemap.ApplicationCore.Errors;
using Homemap.ApplicationCore.Interfaces.Repositories;
using Homemap.ApplicationCore.Interfaces.Services;
using Homemap.ApplicationCore.Models;
using Homemap.Domain.Core;

public class ReceiverService : IReceiverService {

    protected readonly IMapper _mapper;
    private readonly IReceiverRepository _repository;

    public ReceiverService(IMapper mapper, IReceiverRepository repository) {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<ReceiverDto>> GetAllAsync(int projectId) {
        var receivers = await _repository.FindByParentAsync(projectId);
        return _mapper.Map<IReadOnlyList<ReceiverDto>>(receivers);
    }

    public async Task<ReceiverDto> CreateAsync(ReceiverDto dto) {
        Receiver receiverEntity = _mapper.Map<Receiver>(dto);
        await _repository.AddAsync(receiverEntity);
        await _repository.SaveAsync();
        return _mapper.Map<ReceiverDto>(receiverEntity);
    }

    public async Task<ErrorOr<Deleted>> DeleteAsync(int id) {
        Receiver? receiverEntity = await _repository.FindByIdAsync(id);
        if (receiverEntity == null) {
            return UserErrors.EntityNotFound($"Receiver with ID {id} was not found.");
        }

        _repository.Remove(receiverEntity);
        await _repository.SaveAsync();
        return Result.Deleted;
    }

    public async Task<ErrorOr<ReceiverDto>> GetByIdAsync(int projectId, int receiverId) {
        var receiverEntity = await _repository.FindByConditionAsync(r => r.Id == receiverId && r.ProjectId == projectId);
        if (receiverEntity == null) {
            return Error.NotFound("Receiver.NotFound", $"Receiver with ID {receiverId} in Project with ID {projectId} was not found.");
        }
        return _mapper.Map<ReceiverDto>(receiverEntity);
    }

    public Task<ErrorOr<ReceiverDto>> UpdateAsync(int id, ReceiverDto dto) {
        throw new NotImplementedException();
    }
}