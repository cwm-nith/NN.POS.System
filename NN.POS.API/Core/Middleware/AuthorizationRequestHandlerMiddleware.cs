using NN.POS.API.Core.Exceptions;

namespace NN.POS.API.Core.Middleware;
public sealed class AuthorizationRequestHandlerMiddleware(RequestDelegate next, ILogger<AuthorizationRequestHandlerMiddleware> logger)
{
    public Task Invoke(HttpContext context)
    {
        //var path = context.Request.Path.Value;
        //if (path != null && path.Contains("api/webhook/"))
        //{
        //    return next(context);
        //}

        var clientHeader = context.Request.Headers["X-Client"].ToString();
        AppDataSetting.ClientHeaders.TryGetValue(clientHeader, out var client);
        if (string.IsNullOrEmpty(client))
        {
            throw new UnAuthorizedRequestException();
        }

        logger.LogInformation("Requested Client {@Client}", client);
        return next(context);
    }
}