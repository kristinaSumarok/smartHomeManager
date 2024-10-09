using Homemap.ApplicationCore.Interfaces.Repositories;
using Homemap.ApplicationCore.Interfaces.Services;
using Homemap.ApplicationCore.Models;
using Homemap.Domain.Core;
using Microsoft.AspNetCore.Mvc;

namespace Homemap.WebAPI.Controllers;


public class ReceiversController : BaseController<ReceiverDto> {
    private readonly ReceiverService _receiverService;

    public ReceiversController(ReceiverService receiverService) : base(receiverService) {
        _receiverService = receiverService;
    }

    [Route("/{projectId}/receivers")]
    [HttpGet]
    public async Task<IActionResult> GetReceiversByProject(int projectId) {
        var receivers = await _receiverService.GetReceiversByProjectAsync(projectId);

        if (receivers == null || receivers.Count == 0) {
            return NotFound($"No receivers found for project with ID {projectId}");
        }

        return Ok(receivers);
    }
}

