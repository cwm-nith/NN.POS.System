using NN.POS.Model.Dtos.Purchases.PurchasePO;
using NN.POS.Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.API.Infra.Tables.Purchases.PurchasePO;

[Table("purchase_po_details")]
public class PurchasePODetailTable : BaseTable
{
    [Column("purchase_po_id")]
    public int PurchasePOId { get; set; }

    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("uom_id")]
    public int UomId { get; set; }

    [Column("local_ccy_id")]
    public int LocalCcyId { get; set; }

    [Column("discount_value", TypeName = "decimal(18,3)")]
    public decimal DiscountValue { get; set; }

    [Column("discount_type")]
    public DiscountType DiscountType { get; set; }

    [Column("qty", TypeName = "decimal(18,3)")]
    public decimal Qty { get; set; }

    [Column("purchase_price", TypeName = "decimal(18,3)")]
    public decimal PurchasePrice { get; set; }

    [Column("total", TypeName = "decimal(18,3)")]
    public decimal Total { get; set; }

    [Column("total_sys", TypeName = "decimal(18,3)")]
    public decimal TotalSys { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    public PurchasePOTable? PurchasePO { get; set; }
}

public static class PurchasePODetailExtensions
{
    public static PurchasePODetailDto ToDto(this PurchasePODetailTable p, 
        string? localCcyName = null, string? itemName = null, string? uomName = null) => new()
    {
        CreatedAt = p.CreatedAt,
        DiscountType = p.DiscountType,
        DiscountValue = p.DiscountValue,
        Id = p.Id,
        IsDeleted = p.IsDeleted,
        ItemId = p.ItemId,
        ItemName = itemName,
        LocalCcyId = p.LocalCcyId,
        LocalCcyName = localCcyName,
        PurchasePOId = p.PurchasePOId,
        PurchasePrice = p.PurchasePrice,
        Qty = p.Qty,
        Total = p.Total,
        TotalSys = p.TotalSys,
        UomId = p.UomId,
        UomName = uomName
    };

    public static PurchasePODetailTable ToTable(this PurchasePODetailDto p) => new()
    {
        CreatedAt = p.CreatedAt,
        Id = p.Id,
        IsDeleted = p.IsDeleted,
        LocalCcyId = p.LocalCcyId,
        DiscountType = p.DiscountType,
        DiscountValue = p.DiscountValue,
        ItemId = p.ItemId,
        PurchasePOId = p.PurchasePOId,
        PurchasePrice = p.PurchasePrice,
        Qty = p.Qty,
        Total = p.Total,
        TotalSys = p.TotalSys,
        UomId = p.UomId
    };
}