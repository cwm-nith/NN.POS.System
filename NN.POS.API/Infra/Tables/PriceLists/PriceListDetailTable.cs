using NN.POS.Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.API.Infra.Tables.PriceLists;

public class PriceListDetailTable : BaseTable
{
    [Column("price_list_id")]
    public int PriceListId { get; set; }

    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("uom_id")]
    public int? UomId { get; set; }

    [Column("ccy_id")]
    public int CcyId { get; set; }

    [Column("discount_value")]
    public decimal DiscountValue { get; set; }

    [Column("discount_type")]
    public DiscountType DiscountType { get; set; } = DiscountType.Percentage;

    [Column("promotion_id")]
    public int PromotionId { get; set; }

    [Column("cost")]
    public decimal Cost { get; set; } // purchase price

    [Column("price")]
    public decimal Price { get; set; } // sale price

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}