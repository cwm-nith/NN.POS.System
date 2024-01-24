using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.Web.States.CompanyStates;

public interface ICompanyStateService : IStateBaseService
{
    void SetBaseCurrencyExchangeRate(CurrencyDto? baseCurrencyExchangeRate, bool isNotify = false);
    void SetLocalCurrencyExchangeRate(CurrencyDto? localCurrencyExchangeRate, bool isNotify = false);

    Task<CurrencyDto?> GetBaseCurrencyExchangeRateAsync();
    Task<CurrencyDto?> GetLocalCurrencyExchangeRateAsync();
}
