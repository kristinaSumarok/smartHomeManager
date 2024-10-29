using FluentValidation;
using Homemap.ApplicationCore.Interfaces.Services;
using Homemap.ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Homemap.WebAPI.Controllers;

public class DevicesController : BaseController<DeviceDto>
{
    private readonly IDeviceService _service;

    private readonly IValidator<DeviceDto> _validator;

    public DevicesController(IDeviceService deviceService, IValidator<DeviceDto> validator) : base(deviceService, validator)
    {
        _service = deviceService;
        _validator = validator;
    }

    [NonAction]
    public override Task<ActionResult<IReadOnlyList<DeviceDto>>> GetAll() => null!;

    [NonAction]
    public override Task<ActionResult<DeviceDto>> Create([FromBody] DeviceDto dto) => null!;

    [HttpGet("/api/receivers/{receiverId}/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDevicesByReceiver(int receiverId)
    {
        var dtoOrError = await _service.GetAllAsync(receiverId);

        if (dtoOrError.IsError)
            return ErrorOf(dtoOrError.FirstError);

        return Ok(dtoOrError.Value);
    }

    [HttpPost("/api/receivers/{receiverId}/[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateDevice(int receiverId, [FromBody] DeviceDto dto)
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

        var dtoOrError = await _service.CreateAsync(receiverId, dto);

        return dtoOrError.MatchFirst(
            createdDevice => CreatedAtAction(nameof(CreateDevice), new { createdDevice.Id }, createdDevice),
            firstError => ErrorOf(firstError)
        );
    }
}
