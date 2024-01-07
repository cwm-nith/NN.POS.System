using NN.POS.Model.Enums;

namespace NN.POS.Model.Dtos.PriceLists;

public class PriceListDetailDto : IBaseDto
{
    public int Id { get; set; }
    public int PriceListId { get; set; }
    public string? PriceListName { get; set; }
    public int ItemId { get; set; }
    public string? ItemName { get; set; }
    public string? ItemBarcode { get; set; }
    public ItemMasterDataProcess? ItemProcess { get; set; }
    public int? UomId { get; set; }
    public string? UomName { get; set; }
    public int CcyId { get; set; }
    public string? CcyName { get; set; }
    public decimal DiscountValue { get; set; }
    public DiscountType DiscountType { get; set; } = DiscountType.Percentage;
    public int PromotionId { get; set; }
    public decimal Cost { get; set; } // purchase price
    public decimal Price { get; set; } // sale price
    public DateTime CreatedAt { get; set; }
}