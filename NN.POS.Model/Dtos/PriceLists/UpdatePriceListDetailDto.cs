using NN.POS.Model.Enums;

namespace NN.POS.Model.Dtos.PriceLists;

public class UpdatePriceListDetailDto
{
    public int? UomId { get; set; }
    public int CcyId { get; set; }
    public decimal DiscountValue { get; set; }
    public DiscountType DiscountType { get; set; } = DiscountType.Percentage;
    public int PromotionId { get; set; }
    public decimal Cost { get; set; } // purchase price
    public decimal Price { get; set; } // sale price
}