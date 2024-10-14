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
   
    [HttpGet]
    public async Task<IActionResult> GetReceiversByProject(int projectId) {
        var receivers = await _service.GetAllAsync(projectId);

        if (receivers == null || receivers.Count == 0) {
            return NotFound($"No receivers found for project with ID {projectId}");
        }

        return Ok(receivers);
    }
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetReceiverById(int projectId, int id) {
        var result = await _service.GetByIdAsync(projectId, id);

        return result.Match<IActionResult>(
            receiver => Ok(receiver),
            errors => NotFound(string.Join(", ", errors.Select(e => e.Description)))
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReceiver(int projectId, int id) {
        var result = await _service.DeleteAsync(projectId, id);

        return result.Match<IActionResult>(
            success => NoContent(),
            errors => NotFound(string.Join(", ", errors.Select(e => e.Description)))
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReceiver(int projectId, int id, [FromBody] ReceiverDto dto) {
        var result = await _service.UpdateAsync(projectId, id, dto);

        return result.Match<IActionResult>(
            updatedReceiver => Ok(updatedReceiver),
            errors => NotFound(string.Join(", ", errors.Select(e => e.Description)))
        );
    }
    [HttpPost]
    public async Task<IActionResult> CreateReceiver(int projectId, [FromBody] ReceiverDto dto) {
        var result = await _service.CreateAsync(projectId, dto);

        return result.Match<IActionResult>(
            createdReceiver => CreatedAtAction(nameof(GetReceiverById), new { projectId = projectId, id = createdReceiver.Id }, createdReceiver),
            errors => NotFound(string.Join(", ", errors.Select(e => e.Description)))
        );
    }






}

