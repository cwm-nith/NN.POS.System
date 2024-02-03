namespace NN.POS.API.Core.Exceptions.Purchases;

public class PurchaseAPNotFoundException : BaseException
{
    public override string Code => "pur_ap_nf";

    public PurchaseAPNotFoundException(string invoice) : base($"Purchase AP with invoice \"{invoice}\" could not be found")
    {

    }

    public PurchaseAPNotFoundException(int id) : base($"Purchase AP with id \"{id}\" could not be found")
    {

    }
}