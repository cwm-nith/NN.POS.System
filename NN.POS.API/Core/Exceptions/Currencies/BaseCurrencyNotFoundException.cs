namespace NN.POS.API.Core.Exceptions.Currencies;

public class BaseCurrencyNotFoundException() : BaseException("Base currency not yet setup.")
{
    public override string Code => "base_curr_nf";
}