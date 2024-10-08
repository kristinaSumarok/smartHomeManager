using Homemap.ApplicationCore.Interfaces.Services;
using Homemap.ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homemap.WebAPI.Controllers;

[Route("projects/{projectId}/receivers")]
public class ReceiversController : BaseController<ReceiverDto> {
    
    public ReceiversController(IService<ReceiverDto> receiverService) : base(receiverService) {
        
    }

}

