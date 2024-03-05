namespace NN.POS.Model.Dtos.Purchases;
public class ItemOutOfStockOrNotYetPurchaseDto
{
    public int ItemId { get; set; }
    public string? Code { get; set; }
    public string? ItemName { get; set; }
    public decimal InStock { get; set; }
    public decimal OrderQty { get; set; }
    public decimal Committed { get; set; }
}

public class ItemOutOfStockOrNotYetPurchaseMasterDto
{
    public List<ItemOutOfStockOrNotYetPurchaseDto> ItemReturns { get; set; } = [];
    public List<ItemOutOfStockOrNotYetPurchaseDto> ItemNotYetPurchaseReturns { get; set; } = [];
}