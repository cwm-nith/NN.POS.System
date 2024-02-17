namespace NN.POS.API.Core.Exceptions.Purchases;

public class PurchaseCreditMemoNotFoundException : BaseException
{
    public override string Code => "pur_memo_nf";

    public PurchaseCreditMemoNotFoundException(string invoice) : base($"Purchase Credit Memo with invoice \"{invoice}\" could not be found")
    {

    }

    public PurchaseCreditMemoNotFoundException(int id) : base($"Purchase Credit Memo with id \"{id}\" could not be found")
    {

    }
}