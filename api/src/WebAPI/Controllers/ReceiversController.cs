using FluentValidation;
using Homemap.ApplicationCore.Interfaces.Services;
using Homemap.ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Homemap.WebAPI.Controllers;

public class ReceiversController : BaseController<ReceiverDto>
{
    private readonly IReceiverService _service;

    private readonly IValidator<ReceiverDto> _validator;

    public ReceiversController(IReceiverService receiverService, IValidator<ReceiverDto> validator) : base(receiverService, validator)
    {
        _service = receiverService;
        _validator = validator;
    }

    [NonAction]
    public override Task<ActionResult<IReadOnlyList<ReceiverDto>>> GetAll() => null!;

    [NonAction]
    public override Task<ActionResult<ReceiverDto>> Create([FromBody] ReceiverDto dto) => null!;

    [NonAction]
    public override Task<ActionResult<ReceiverDto>> Update(int id, [FromBody] ReceiverDto dto) => null!;

    [HttpGet("/api/projects/{projectId}/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetReceiversByProject(int projectId)
    {
        var dtoOrError = await _service.GetAllAsync(projectId);

        if (dtoOrError.IsError)
            return ErrorOf(dtoOrError.FirstError);

        return Ok(dtoOrError.Value);
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
            foreach (var error in validationResult.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return BadRequest(ModelState);
        }

        var dtoOrError = await _service.CreateAsync(projectId, dto);

        return dtoOrError.MatchFirst(
            createdReceiver => CreatedAtAction(nameof(CreateReceiver), new { createdReceiver.Id }, createdReceiver),
            firstError => ErrorOf(firstError)
        );
    }
}
