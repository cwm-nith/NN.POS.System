namespace NN.POS.API.Core.Exceptions.Purchases;

public class PurchasePONotFoundException : BaseException
{
    public override string Code => "pur_po_nf";

    public PurchasePONotFoundException(string invoice) : base($"Purchase PO with invoice \"{invoice}\" could not be found")
    {
        
    }

    public PurchasePONotFoundException(int id) : base($"Purchase PO with id \"{id}\" could not be found")
    {

    }
}