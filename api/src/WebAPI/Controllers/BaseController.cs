using ErrorOr;
using FluentValidation;
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

        private readonly IValidator<T> _validator;

        public BaseController(IService<T> service, IValidator<T> validator)
        {
            _service = service;
            _validator = validator;
        }

        /// <returns>Erroneous ActionResult from supplied Error</returns>
        protected ActionResult ErrorOf(Error error)
        {
            return error.Type switch
            {
                ErrorType.NotFound => NotFound(),
                ErrorType.Unauthorized => Unauthorized(),
                ErrorType.Validation => BadRequest(ModelState),
                _ => Problem(
                        type: error.Code,
                        title: error.Description,
                        detail: (error.Metadata?.TryGetValue("details", out object? details) ?? false) ? details.ToString() : null)
            };
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<ActionResult<IReadOnlyList<T>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<T>> GetById(int id)
        {
            ErrorOr<T> dtoOrError = await _service.GetByIdAsync(id);

            if (dtoOrError.IsError)
                return ErrorOf(dtoOrError.FirstError);

            return dtoOrError.Value;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<ActionResult<T>> Create([FromBody] T dto)
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

            dto = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(Create), new { dto.Id }, dto);
        }

        [HttpPut("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<ActionResult<T>> Update(int id, [FromBody] T dto)
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

            ErrorOr<T> dtoOrError = await _service.UpdateAsync(id, dto);

            if (dtoOrError.IsError)
                return ErrorOf(dtoOrError.FirstError);

            return dtoOrError.Value;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult> Delete(int id)
        {
            ErrorOr<Deleted> deletedOrError = await _service.DeleteAsync(id);

            if (deletedOrError.IsError)
                return ErrorOf(deletedOrError.FirstError);

            return NoContent();
        }   
    }
}
