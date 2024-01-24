using NN.POS.Model.Dtos.Currencies;
using NN.POS.Web.AppSettings;
using NN.POS.Web.Constants;
using System.Net.Http.Json;

namespace NN.POS.Web.States.CompanyStates;

public class CompanyStateService(Setting setting, IHttpClientFactory clientFactory) : ICompanyStateService
{
    private CurrencyDto? BaseCurrencyExchangeRate { get; set; }
    private CurrencyDto? LocalCurrencyExchangeRate { get; set; }

    public event Action? OnStateChange;

    public void SetBaseCurrencyExchangeRate(CurrencyDto? baseCurrencyExchangeRate, bool isNotify = false)
    {
        BaseCurrencyExchangeRate = baseCurrencyExchangeRate;
        if (isNotify)
        {
            NotifyStateChanged();
        }
    }

    public void SetLocalCurrencyExchangeRate(CurrencyDto? localCurrencyExchangeRate, bool isNotify = false)
    {
        LocalCurrencyExchangeRate = localCurrencyExchangeRate;
        if (isNotify)
        {
            NotifyStateChanged();
        }
    }

    /// <summary>
    /// The state change event notification
    /// </summary>
    private void NotifyStateChanged() => OnStateChange?.Invoke();

    public async Task<CurrencyDto?> GetLocalCurrencyExchangeRateAsync()
    {
        if (BaseCurrencyExchangeRate != null) return BaseCurrencyExchangeRate;

        var httpClient = clientFactory.CreateClient(AppConstants.HttpClientName);

        var response = await httpClient.GetFromJsonAsync<CurrencyDto>($"{setting.PrefixEndpoint}currency/local-currency");
        BaseCurrencyExchangeRate = response;
        return response;
    }
    public async Task<CurrencyDto?> GetBaseCurrencyExchangeRateAsync()
    {
        if (LocalCurrencyExchangeRate != null) return LocalCurrencyExchangeRate;

        var httpClient = clientFactory.CreateClient(AppConstants.HttpClientName);

        var response = await httpClient.GetFromJsonAsync<CurrencyDto>($"{setting.PrefixEndpoint}currency/base-currency");
        LocalCurrencyExchangeRate = response;
        return response;
    }
}
