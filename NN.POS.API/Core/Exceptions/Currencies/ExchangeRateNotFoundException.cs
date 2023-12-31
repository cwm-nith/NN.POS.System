namespace NN.POS.API.Core.Exceptions.Currencies;

public class ExchangeRateNotFoundException(int id) : BaseException($"Exchange rate with id \"{id}\" could not be found.")
{
    public override string Code => "ex_rate_nf";
}