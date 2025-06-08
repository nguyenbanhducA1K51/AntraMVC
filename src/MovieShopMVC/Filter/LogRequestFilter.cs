namespace MovieShopMVC.Filter;

using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

public class LogRequestFilter : IActionFilter
{
    private readonly ILogger<LogRequestFilter> _logger;

    public LogRequestFilter(ILogger<LogRequestFilter> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var actionName = context.ActionDescriptor.DisplayName;
        var time = DateTime.UtcNow;
        var request = context.HttpContext.Request;

        _logger.LogInformation("Request to {Action} at {Time}. Method: {Method}, Path: {Path}",
            actionName, time, request.Method, request.Path);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}