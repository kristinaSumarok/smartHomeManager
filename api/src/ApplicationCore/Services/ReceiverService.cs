using AutoMapper;
using ErrorOr;
using Homemap.ApplicationCore.Errors;
using Homemap.ApplicationCore.Interfaces.Repositories;
using Homemap.ApplicationCore.Interfaces.Services;
using Homemap.ApplicationCore.Models;
using Homemap.ApplicationCore.Services;
using Homemap.Domain.Common;
using Homemap.Domain.Core;

public class ReceiverService : BaseService<Receiver, ReceiverDto>, IReceiverService {

    private readonly IMapper _mapper;
    private readonly IReceiverRepository _receiverRepository;
    private readonly ICrudRepository<Project> _projectRepository;

    public ReceiverService(IMapper mapper, IReceiverRepository repository, ICrudRepository<Project> projectRepository) : base(mapper, repository) {
        _receiverRepository = repository;
        _projectRepository = projectRepository;
        _mapper = mapper;
        _projectRepository = projectRepository;
    }

    public async Task<ErrorOr<IReadOnlyList<ReceiverDto>>> GetAllAsync(int projectId) {
        var project = await _projectRepository.FindByIdAsync(projectId);
        if (project == null) {
            return Error.NotFound();
        }
        var receivers = await _receiverRepository.FindAllByProjectId(projectId);
        return _mapper.Map<IReadOnlyList<ReceiverDto>>(receivers).ToErrorOr();
    }

    public async Task<ErrorOr<ReceiverDto>> CreateAsync(int projectId, ReceiverDto dto) {
        var project = await _projectRepository.FindByIdAsync(projectId);
        if (project == null) {
            return Error.NotFound("Project.NotFound", $"Project with ID {projectId} was not found.");
        }
        var receiverEntity = _mapper.Map<Receiver>(dto);
        receiverEntity.Project = project; 
        await _receiverRepository.AddAsync(receiverEntity);
        await _receiverRepository.SaveAsync();
        return _mapper.Map<ReceiverDto>(receiverEntity);
    }

}