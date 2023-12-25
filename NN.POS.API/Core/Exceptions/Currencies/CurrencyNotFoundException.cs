namespace NN.POS.API.Core.Exceptions.Currencies;

public class CurrencyNotFoundException(int id) : BaseException($"Currency with id \"{id}\" could not be found.")
{
    public override string Code => "ccy_nf";
}