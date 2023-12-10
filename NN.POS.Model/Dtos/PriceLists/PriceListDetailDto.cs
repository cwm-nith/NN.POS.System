using NN.POS.Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.Model.Dtos.PriceLists;

public class PriceListDetailDto : IBaseDto
{
    public int Id { get; set; }
    public int PriceListId { get; set; }
    public int ItemId { get; set; }
    public int? UomId { get; set; }
    public int CcyId { get; set; }
    public decimal DiscountValue { get; set; }
    public DiscountType DiscountType { get; set; } = DiscountType.Percentage;
    public int PromotionId { get; set; }
    public decimal Cost { get; set; } // purchase price
    public decimal Price { get; set; } // sale price
    public DateTime CreatedAt { get; set; }
}