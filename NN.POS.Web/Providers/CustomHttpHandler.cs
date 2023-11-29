using Blazored.LocalStorage;
using NN.POS.Web.AppSettings;

namespace NN.POS.Web.Providers;

public class CustomHttpHandler : DelegatingHandler
{
    private readonly ILocalStorageService _localStorageService;
    private readonly Setting _setting;
    public CustomHttpHandler(ILocalStorageService localStorageService, Setting setting)
    {
        _localStorageService = localStorageService;
        _setting = setting;
    }
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        
        request.Headers.Add("X-Client", _setting.Code);
        
        if (request.RequestUri != null && (request.RequestUri.AbsolutePath.Contains("login", StringComparison.CurrentCultureIgnoreCase) ||
                                           request.RequestUri.AbsolutePath.Contains("register", StringComparison.CurrentCultureIgnoreCase)))
        {
            return await base.SendAsync(request, cancellationToken);
        }

        var token = await _localStorageService.GetItemAsync<string>("jat", cancellationToken);
        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Add("Authorization", $"Bearer {token}");
        }

        return await base.SendAsync(request, cancellationToken);
    }
}