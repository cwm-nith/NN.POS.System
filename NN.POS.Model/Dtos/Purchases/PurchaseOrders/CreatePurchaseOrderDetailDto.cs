using NN.POS.Model.Enums;

namespace NN.POS.Model.Dtos.Purchases.PurchaseOrders;

public class CreatePurchaseOrderDetailDto : IBaseDto
{
    public int ItemId { get; set; }
    public int UomId { get; set; }
    public int LocalCcyId { get; set; }
    public decimal DiscountRate { get; set; }
    public decimal DiscountValue { get; set; }
    public DiscountType DiscountType { get; set; }
    public decimal Qty { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal Total { get; set; }
    public decimal TotalSys { get; set; }
}