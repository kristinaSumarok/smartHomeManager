using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace Homemap.WebAPI.Extensions
{
    public static class ErrorExtensions
    {
        /// <returns>Erroneous ActionResult from supplied Error</returns>
        public static ActionResult ErrorOf(this ControllerBase controller, Error error)
        {
            return error.Type switch
            {
                ErrorType.NotFound => controller.NotFound(),
                ErrorType.Unauthorized => controller.Unauthorized(),
                ErrorType.Validation => controller.BadRequest(controller.ModelState),
                _ => controller.Problem(
                        type: error.Code,
                        title: error.Description,
                        detail: (error.Metadata?.TryGetValue("details", out object? details) ?? false) ? details.ToString() : null)
            };
        }
    }
}
