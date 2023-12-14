namespace NN.POS.API.Core.Exceptions.ItemMasters;

public class BarcodeOrCodeNeedToHaveOneException() : BaseException("Barcode or Code need to have value either one.")
{
    public override string Code => "item_bar_code_one";
}