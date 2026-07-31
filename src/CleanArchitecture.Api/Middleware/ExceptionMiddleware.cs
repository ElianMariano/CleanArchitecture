using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace CleanArchitecture.Api.Middleware;

public class ExceptionMiddleware : IExceptionHandler
{
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IStringLocalizer<SharedResources> _localizer;

    public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, IStringLocalizer<SharedResources> localizer)
    {
        _logger = logger;
        _localizer = localizer;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, exception.Message);

        httpContext.Response.ContentType = "application/json";

        var problem = exception switch
        {
            ItemNotFoundException ex => new ProblemDetails
            {
                Title = nameof(ItemNotFoundException),
                Detail = _localizer[ApplicationExceptionMessages.ITEM_NOT_FOUND, ex.Parameters],
                Status = StatusCodes.Status400BadRequest
            },
            BusinessException ex => new ProblemDetails
            {
                Title = nameof(BusinessException),
                Detail = _localizer[DomainExceptionMessages.ITEM_NEGATIVE_VALUE],
                Status = StatusCodes.Status404NotFound
            },
            _ => new ProblemDetails
            {
                Title = _localizer["UnexpectedError"],
                Detail = exception.ToString(),
                Status = StatusCodes.Status500InternalServerError
            }
        };

        httpContext.Response.StatusCode = problem.Status!.Value;

        await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);

        return true;
    }
}