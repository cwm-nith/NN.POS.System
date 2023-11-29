namespace NN.POS.API.Core.Middleware.Logging;

public class LogUserIdMiddleware(RequestDelegate next, ILogger logger)
{
    public Task Invoke(HttpContext context)
    {
        logger.LogInformation("UserId => {userId}", context.User.Identity?.Name);

        return next(context);
    }
}