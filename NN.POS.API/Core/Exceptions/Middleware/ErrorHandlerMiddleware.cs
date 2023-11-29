using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NN.POS.API.Core.Exceptions.Middleware;

public class ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            var additionalData = new object();
            var statusCode = 400;
            var code = string.Empty;
            if (exception is BaseException baseException)
            {
                additionalData = baseException.AdditionalData;
                statusCode = baseException.StatusCode;
                code = baseException.Code;
            }

            logger.LogError(exception, "{Message}{AdditionalData}", exception.Message, additionalData);
            await HandleErrorAsync(context, exception, statusCode, code);
        }
    }

    private static Task HandleErrorAsync(HttpContext context, Exception exception, int statusCode, string code)
    {
        var response = new { code, message = exception.Message };
        var payload = JsonConvert.SerializeObject(response,
            new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;
        return context.Response.WriteAsync(payload);
    }
}