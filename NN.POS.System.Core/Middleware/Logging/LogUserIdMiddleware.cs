using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace NN.POS.System.Core.Middleware.Logging;

public class LogUserIdMiddleware
{
    private readonly ILogger<LogUserIdMiddleware> _logger;
    private readonly RequestDelegate _next;

    public LogUserIdMiddleware(RequestDelegate next, ILogger<LogUserIdMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public Task Invoke(HttpContext context)
    {
        _logger.LogInformation($"UserId => { context.User?.Identity?.Name}");

        return _next(context);
    }
}