namespace NN.POS.API.Core.Exceptions.Purchases;

public class PurchaseOrderNotFoundException : BaseException
{
    public override string Code => "pur_order_nf";

    public PurchaseOrderNotFoundException(string invoice) : base($"Purchase order with invoice \"{invoice}\" could not be found")
    {
        
    }

    public PurchaseOrderNotFoundException(int id) : base($"Purchase order with id \"{id}\" could not be found")
    {

    }
}