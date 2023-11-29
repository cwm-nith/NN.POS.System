namespace NN.POS.API.Core.Middleware;

public class LogMiddleware(RequestDelegate next, ILogger<LogMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        var clientId = context.Request.Headers["X-ClientId"].ToString();
        var clientIp = context.Request.Headers["X-Real-IP"].ToString();
        var userId = context.User.Identity?.Name;


        logger.LogInformation("Requested from ip: {@IP}, client id: {@ClientId}, user id: {@UserId}", clientIp, clientId,
            userId ?? string.Empty);
        await next(context);
    }
}