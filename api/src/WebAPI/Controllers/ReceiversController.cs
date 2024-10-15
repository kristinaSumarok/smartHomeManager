using ErrorOr;
using Homemap.ApplicationCore.Interfaces.Repositories;
using Homemap.ApplicationCore.Interfaces.Services;
using Homemap.ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

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

        var result = await _service.GetAllAsync(projectId);

        if (result.IsError) {

            if (result.FirstError == Error.NotFound()) {
                return NotFound($"project with ID {projectId} doesn't exists");
            }

            return  NoContent();
        }
        return Ok(result.Value);
    }
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetReceiverById(int id) {
        var result = await _service.GetByIdAsync(id);

        return result.Match<IActionResult>(
            receiver => Ok(receiver),
            errors => NotFound(string.Join(", ", errors.Select(e => e.Description)))
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReceiver(int id) {
        var result = await _service.DeleteAsync(id);

        return result.Match<IActionResult>(
            success => NoContent(),
            errors => NotFound(string.Join(", ", errors.Select(e => e.Description)))
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReceiver(int id, [FromBody] ReceiverDto dto) {
        var result = await _service.UpdateAsync(id, dto);

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

