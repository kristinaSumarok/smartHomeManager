using AutoMapper;
using ErrorOr;
using Homemap.ApplicationCore.Errors;
using Homemap.ApplicationCore.Interfaces.Repositories;
using Homemap.ApplicationCore.Interfaces.Services;
using Homemap.ApplicationCore.Models;
using Homemap.ApplicationCore.Services;
using Homemap.Domain.Core;

public class ReceiverService : BaseService<Receiver, ReceiverDto>, IReceiverService
{

    private readonly IMapper _mapper;

    private readonly IReceiverRepository _receiverRepository;

    private readonly ICrudRepository<Project> _projectRepository;

    public ReceiverService(
        IMapper mapper,
        IReceiverRepository receiverRepository,
        ICrudRepository<Project> projectRepository
    ) : base(mapper, receiverRepository)
    {
        _receiverRepository = receiverRepository;
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<IReadOnlyList<ReceiverDto>>> GetAllAsync(int projectId)
    {
        Project? project = await _projectRepository.FindByIdAsync(projectId);

        if (project == null)
        {
            return UserErrors.EntityNotFound($"Project was not found ('{projectId}')");
        }

        IReadOnlyList<Receiver> receivers = await _receiverRepository.FindAllByProjectId(projectId);
        return _mapper.Map<IReadOnlyList<ReceiverDto>>(receivers).ToErrorOr();
    }

    public async Task<ErrorOr<ReceiverDto>> CreateAsync(int projectId, ReceiverDto dto)
    {
        Project? project = await _projectRepository.FindByIdAsync(projectId);

        if (project == null)
        {
            return UserErrors.EntityNotFound($"Project was not found ('{projectId}')");
        }

        Receiver receiverEntity = _mapper.Map<Receiver>(dto);
        receiverEntity.Project = project;

        await _receiverRepository.AddAsync(receiverEntity);
        await _receiverRepository.SaveAsync();

        return _mapper.Map<ReceiverDto>(receiverEntity);
    }
}
