namespace NN.POS.API.Core.Exceptions.PriceLists;

public class PriceListNotFoundException(int id) : BaseException($"Price List with Id \"{id}\" could be found.")
{
    public override string Code => "pl_nf";
}