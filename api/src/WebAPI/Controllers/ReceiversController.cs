using ErrorOr;
using FluentValidation;
using Homemap.ApplicationCore.Interfaces.Services;
using Homemap.ApplicationCore.Models;
using Homemap.WebAPI.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Homemap.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReceiversController : ControllerBase
{
    private readonly IReceiverService _service;

    private readonly IValidator<ReceiverDto> _validator;

    public ReceiversController(IReceiverService receiverService, IValidator<ReceiverDto> validator)
    {
        _service = receiverService;
        _validator = validator;
    }

    [HttpGet("/api/projects/{projectId}/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllByProject(int projectId)
    {
        var dtoOrError = await _service.GetAllAsync(projectId);

        if (dtoOrError.IsError)
            return this.ErrorOf(dtoOrError.FirstError);

        return Ok(dtoOrError.Value);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ReceiverDto>> GetById(int id)
    {
        ErrorOr<ReceiverDto> dtoOrError = await _service.GetByIdAsync(id);

        if (dtoOrError.IsError)
            return this.ErrorOf(dtoOrError.FirstError);

        return dtoOrError.Value;
    }

    [HttpPost("/api/projects/{projectId}/[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateReceiver(int projectId, [FromBody] ReceiverDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);

        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(ModelState);

            return BadRequest(ModelState);
        }

        var dtoOrError = await _service.CreateAsync(projectId, dto);

        return dtoOrError.MatchFirst(
            createdReceiver => CreatedAtAction(nameof(CreateReceiver), new { createdReceiver.Id }, createdReceiver),
            firstError => this.ErrorOf(firstError)
        );
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        ErrorOr<Deleted> deletedOrError = await _service.DeleteAsync(id);

        if (deletedOrError.IsError)
            return this.ErrorOf(deletedOrError.FirstError);

        return NoContent();
    }
}
