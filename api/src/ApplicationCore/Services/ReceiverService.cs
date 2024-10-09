using AutoMapper;
using Homemap.ApplicationCore.Interfaces.Repositories;
using Homemap.ApplicationCore.Models;
using Homemap.ApplicationCore.Services;
using Homemap.Domain.Core;

public class ReceiverService : BaseService<Receiver, ReceiverDto> {
    
    public ReceiverService(IMapper mapper, ICrudRepository<Receiver> repository) : base(mapper, repository) {
    }
    
}