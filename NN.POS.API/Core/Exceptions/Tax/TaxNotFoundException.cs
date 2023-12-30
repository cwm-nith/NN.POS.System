namespace NN.POS.API.Core.Exceptions.Tax;

public class TaxNotFoundException(int id) : BaseException($"Tax with id \"{id}\" could not be found")
{
    public override string Code => "tax_nf";
}