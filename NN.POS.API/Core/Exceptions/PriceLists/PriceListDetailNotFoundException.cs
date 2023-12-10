namespace NN.POS.API.Core.Exceptions.PriceLists;

public class PriceListDetailNotFoundException(int id) : BaseException($"Price List Detail with Id \"{id}\" could be found.")
{
    public override string Code => "pld_nf";
}