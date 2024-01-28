using NN.POS.Model.Enums;

namespace NN.POS.Model.Dtos.Purchases.PurchasePO;
public class PurchasePODetailDto : IBaseDto
{
    public int Id { get; set; }
    public int PurchasePOId { get; set; }
    public int ItemId { get; set; }
    public string? ItemName { get; set; }
    public int UomId { get; set; }
    public string? UomName { get; set; }
    public int LocalCcyId { get; set; }
    public string? LocalCcyName { get; set; }
    public decimal DiscountValue { get; set; }
    public DiscountType DiscountType { get; set; }
    public decimal Qty { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal Total { get; set; }
    public decimal TotalSys { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
}
