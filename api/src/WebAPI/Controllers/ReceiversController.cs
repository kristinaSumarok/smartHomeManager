using Homemap.ApplicationCore.Interfaces.Services;
using Homemap.ApplicationCore.Models;
using Homemap.Infrastructure.Data.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace Homemap.WebAPI.Controllers;

public class ReceiversController : BaseController<ReceiverDto> {

    public ReceiversController(IService<ReceiverDto> receiverService)
        : base(receiverService) {
    }
}

