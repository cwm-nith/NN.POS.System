using NN.POS.Model.Dtos.UnitOfMeasures;
using NN.POS.Model.Enums;

namespace NN.POS.Model.Dtos.Purchases;

public class PurchaseItemDto : IBaseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string OtherName { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Barcode { get; set; } = string.Empty;
    public int UomId { get; set; }
    public int UomGroupId { get; set; }
    public decimal DiscountValue { get; set; }
    public DiscountType DiscountType { get; set; }
    public decimal Qty { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal Total { get; set; }
    public decimal TotalSys { get; set; }
    public List<UnitOfMeasureDefineDto> Uoms { get; set; } = [];
}