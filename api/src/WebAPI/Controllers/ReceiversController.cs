using Homemap.ApplicationCore.Interfaces.Repositories;
using Homemap.ApplicationCore.Interfaces.Services;
using Homemap.ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homemap.WebAPI.Controllers;

[Route("api/Projects/{projectId}/[controller]")]
[ApiController]
public class ReceiversController: ControllerBase {

     private readonly IReceiverService _service;

    public ReceiversController(IReceiverService receiverService) {
        _service = receiverService;
    }
   
    [HttpGet("all")]
    public async Task<IActionResult> GetReceiversByProject(int projectId) {
        var receivers = await _service.GetAllAsync(projectId);

        if (receivers == null || receivers.Count == 0) {
            return NotFound($"No receivers found for project with ID {projectId}");
        }

        return Ok(receivers);
    }
    [HttpGet("{receiverId}")]
    public async Task<IActionResult> GetReceiverById(int projectId, int receiverId) {
        var result = await _service.GetByIdAsync(projectId, receiverId);

        return result.Match<IActionResult>(
            receiver => Ok(receiver),
            errors => NotFound(string.Join(", ", errors.Select(e => e.Description)))
        );
    }
}

