using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Potres.Common.Extensions;
using System;

namespace Potres.Util.ServiceFilters
{
  public class BadRequestOnArgumentException : ExceptionFilterAttribute
  {
    private readonly ILogger<BadRequestOnArgumentException> logger;

    public BadRequestOnArgumentException(ILogger<BadRequestOnArgumentException> logger)
    {
      this.logger = logger;
    }

    public override void OnException(ExceptionContext context)
    {
      if (context.Exception is ArgumentException)
      {
        string exceptionMessage = context.Exception.CompleteExceptionMessage();
        logger.LogDebug("Neispravan argument: {0}", exceptionMessage);
        context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        context.ExceptionHandled = true;

        var problemDetails = new ProblemDetails
        {
          Detail = exceptionMessage,
          Title = "Validation exception",
          Instance = context.HttpContext.TraceIdentifier
        };
        context.Result = new ObjectResult(problemDetails)
        {
          ContentTypes = { "application/problem+json" },
          StatusCode = StatusCodes.Status400BadRequest
        };
      }
      base.OnException(context);
    }
  }
}
