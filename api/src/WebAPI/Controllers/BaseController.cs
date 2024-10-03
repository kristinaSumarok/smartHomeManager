using Homemap.ApplicationCore.Interfaces.Services;
using Homemap.ApplicationCore.Models.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Homemap.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : EntityDto
    {
        private readonly IService<T> _service;

        public BaseController(IService<T> service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<T>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<T>> GetById(int id)
        {
            T? dto = await _service.GetByIdAsync(id);

            if (dto is null)
                return NotFound();

            return dto;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<T>> Create([FromBody] T dto)
        {
            // TODO: validation, fluent validation
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            dto = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(Create), new { dto.Id }, dto);
        }

        [HttpPut("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<T>> Update(int id, [FromBody] T dto)
        {
            // TODO: validation, fluent validation
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            T? updatedDto = await _service.UpdateAsync(id, dto);

            if (updatedDto is null)
                return NotFound();

            return updatedDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}
