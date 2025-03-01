using Microsoft.AspNetCore.Mvc;
using Support.Application.Common.Models.Errors;
using Support.Application.Errors;

namespace Support.API.Helpers;

public static class ResponseHelper
{
    public static IActionResult HandleResponse<TValue>(Result<InternalError, TValue> result)
    {
        return result.Match(
            HandleError,
            value => new OkObjectResult(value));
    }

    private static IActionResult HandleError(InternalError error)
    {
        return error switch
        {
            NotFoundError notFoundError => new NotFoundObjectResult(new ErrorResponse(notFoundError.Message, StatusCodes.Status404NotFound)),
            ValidationError validationError => new BadRequestObjectResult(new ErrorResponse(validationError.Message, StatusCodes.Status400BadRequest, errors: validationError.Errors)),
            NotTicketsFoundError notTicketsFoundError => new NotFoundObjectResult(new ErrorResponse(notTicketsFoundError.Message, StatusCodes.Status404NotFound, errors: notTicketsFoundError.Errors)),
            _ => new ObjectResult(new ErrorResponse(error.Message, StatusCodes.Status500InternalServerError))
            {
                StatusCode = StatusCodes.Status500InternalServerError
            }
        };
    }
}