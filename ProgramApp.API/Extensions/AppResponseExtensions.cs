using Microsoft.AspNetCore.Mvc;
using ProgramApp.Application;

namespace ProgramApp.API.Extensions
{
    public static class AppResponseExtensions
    {
        public static IActionResult ToActionResult<T>(this AppResponse<T> result)
        {
            return (int)result.StatusCode switch
            {
                StatusCodes.Status200OK => new OkObjectResult(result),
                StatusCodes.Status404NotFound => new NotFoundObjectResult(result),
                StatusCodes.Status400BadRequest => new BadRequestObjectResult(result),
                StatusCodes.Status500InternalServerError => new ObjectResult(result) { StatusCode = (int)result.StatusCode },
                _ => new StatusCodeResult((int)result.StatusCode),
            };
        }
    }
}
