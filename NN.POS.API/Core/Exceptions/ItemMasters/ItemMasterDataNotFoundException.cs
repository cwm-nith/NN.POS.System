namespace NN.POS.API.Core.Exceptions.ItemMasters;

public class ItemMasterDataNotFoundException : BaseException
{
    private const string CodeName = "code";
    private const string Barcode = "barcode";
    public override string Code => "item_nf";

    public ItemMasterDataNotFoundException(int id) : base($"Item master data with id \"{id}\" could not be found.")
    {

    }

    public ItemMasterDataNotFoundException(string code, bool isBarcode) : base(
        $"Item master data with {(isBarcode ? Barcode : CodeName)} \"{code}\" could not be found.")
    {
    }

}