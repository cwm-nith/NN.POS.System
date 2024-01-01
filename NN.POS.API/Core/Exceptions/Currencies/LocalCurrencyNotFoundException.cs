namespace NN.POS.API.Core.Exceptions.Currencies;

public class LocalCurrencyNotFoundException() : BaseException("Local currency not yet setup.")
{
    public override string Code => "local_curr_nf";
}