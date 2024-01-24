using System.Net;
using System.Net.Http.Json;
using NN.POS.Model.Dtos;

namespace NN.POS.Web.Helpers;

public static class ErrorApiHelper
{
    public static async Task<string> GetErrorMessageResponse(
        HttpResponseMessage response,
        Func<Task>? unauthorized = null,
        Func<Task>? ok = null)
    {
        switch (response.StatusCode)
        {
            case HttpStatusCode.BadRequest:
                {
                    var errors = await response.Content.ReadFromJsonAsync<ErrorResponse>();

                    var code = !string.IsNullOrEmpty(errors?.Code) ? $" [{errors.Code}]" : "";

                    return $"{errors?.Message}{code}";
                }
            case HttpStatusCode.Unauthorized:
                {
                    unauthorized?.Invoke();
                    return "";
                }
            case HttpStatusCode.OK:
                {
                    ok?.Invoke();
                    return "";
                }
            default:
                return "Something went wrong, Please try after some time";
        }
    }

    public static async Task<string> GetErrorMessageResponse(
        HttpResponseMessage response,
        Action? unauthorized = null,
        Func<Task>? ok = null)
    {
        switch (response.StatusCode)
        {
            case HttpStatusCode.BadRequest:
            {
                var errors = await response.Content.ReadFromJsonAsync<ErrorResponse>();

                var code = !string.IsNullOrEmpty(errors?.Code) ? $" [{errors.Code}]" : "";

                return $"{errors?.Message}{code}";
            }
            case HttpStatusCode.Unauthorized:
            {
                unauthorized?.Invoke();
                return "";
            }
            case HttpStatusCode.OK:
            {
                ok?.Invoke();
                return "";
            }
            default:
                return "Something went wrong, Please try after some time";
        }
    }

    public static async Task<string> GetErrorMessageResponse(
        HttpResponseMessage response,
        Action? unauthorized = null,
        Action? ok = null)
    {
        switch (response.StatusCode)
        {
            case HttpStatusCode.BadRequest:
            {
                var errors = await response.Content.ReadFromJsonAsync<ErrorResponse>();

                var code = !string.IsNullOrEmpty(errors?.Code) ? $" [{errors.Code}]" : "";

                return $"{errors?.Message}{code}";
            }
            case HttpStatusCode.Unauthorized:
            {
                unauthorized?.Invoke();
                return "";
            }
            case HttpStatusCode.OK:
            {
                ok?.Invoke();
                return "";
            }
            default:
                return "Something went wrong, Please try after some time";
        }
    }
}