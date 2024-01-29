using NN.POS.Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using NN.POS.API.Infra.Tables.ItemMasters;
using NN.POS.Model.Dtos.PriceLists;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.API.Infra.Tables.PriceLists;

[Table("price_list_details")]
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

    [Column("discount_value", TypeName = "decimal(18,4)")]
    public decimal DiscountValue { get; set; }

    [Column("discount_type")]
    public DiscountType DiscountType { get; set; } = DiscountType.Percentage;

    [Column("promotion_id")]
    public int PromotionId { get; set; }

    [Column("cost", TypeName = "decimal(18,4)")]
    public decimal Cost { get; set; } // purchase price

    [Column("price", TypeName = "decimal(18,4)")]
    public decimal Price { get; set; } // sale price

    public PriceListTable? PriceList { get; set; }
}

public static class PriceListDetailTableExtensions
{
    public static PriceListDetailTable ToTable(this PriceListDetailDto p) => new()
    {
        Id = p.Id,
        PriceListId = p.PriceListId,
        CreatedAt = p.CreatedAt,
        CcyId = p.CcyId,
        Cost = p.Cost,
        DiscountType = p.DiscountType,
        PromotionId = p.PromotionId,
        DiscountValue = p.DiscountValue,
        ItemId = p.ItemId,
        Price = p.Price,
        UomId = p.UomId
    };

    public static PriceListDetailDto ToDto(this PriceListDetailTable p, 
        string? plName = null, 
        string? ccy = null, 
        ItemMasterDataTable? item = null, 
        string? uom = null,
        ExchangeRateDto? exchangeRate = null) => new()
    {
        Id = p.Id,
        PriceListId = p.PriceListId,
        PriceListName = plName,
        CreatedAt = p.CreatedAt,
        CcyId = p.CcyId,
        CcyName = ccy,
        Cost = p.Cost,
        DiscountType = p.DiscountType,
        PromotionId = p.PromotionId,
        DiscountValue = p.DiscountValue,
        ItemId = p.ItemId,
        ItemName = item?.Name,
        Price = p.Price,
        UomId = p.UomId,
        UomName = uom,
        ItemBarcode = item?.Barcode,
        ItemProcess = item?.Process,
        ExchangeRate = exchangeRate
    };
}