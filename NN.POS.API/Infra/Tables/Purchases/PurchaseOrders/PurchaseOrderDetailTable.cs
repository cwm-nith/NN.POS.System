using System.ComponentModel.DataAnnotations.Schema;
using NN.POS.Model.Dtos.Purchases.PurchaseOrders;
using NN.POS.Model.Enums;

namespace NN.POS.API.Infra.Tables.Purchases.PurchaseOrders;

[Table("purchase_order_details")]
public class PurchaseOrderDetailTable : BaseTable
{
    [Column("purchase_order_id")]
    public int PurchaseOrderId { get; set; }

    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("uom_id")]
    public int UomId { get; set; }

    [Column("local_ccy_id")]
    public int LocalCcyId { get; set; }

    [Column("discount_value", TypeName = "decimal(18,3)")]
    public decimal DiscountRate { get; set; }

    [Column("discount_rate", TypeName = "decimal(18,3)")]
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

    public PurchaseOrderTable? PurchaseOrder { get; set; }
}

public static class PurchaseOrderDetailExtensions
{

    public static PurchaseOrderDetailTable ToTable(this PurchaseOrderDetailDto p) => new()
    {
        CreatedAt = p.CreatedAt,
        Id = p.Id,
        IsDeleted = p.IsDeleted,
        LocalCcyId = p.LocalCcyId,
        DiscountRate = p.DiscountRate,
        DiscountType = p.DiscountType,
        DiscountValue = p.DiscountValue,
        ItemId = p.ItemId,
        PurchaseOrderId = p.PurchaseOrderId,
        PurchasePrice = p.PurchasePrice,
        Qty = p.Qty,
        Total = p.Total,
        TotalSys = p.TotalSys,
        UomId = p.UomId
    };

    public static PurchaseOrderDetailDto ToDto(
        this PurchaseOrderDetailTable p,
        string? localCcyName = null, string? itemName = null, string? uomName = null) => new()
        {
            CreatedAt = p.CreatedAt,
            Id = p.Id,
            IsDeleted = p.IsDeleted,
            LocalCcyId = p.LocalCcyId,
            LocalCcyName = localCcyName,
            DiscountRate = p.DiscountRate,
            DiscountType = p.DiscountType,
            DiscountValue = p.DiscountValue,
            ItemId = p.ItemId,
            ItemName = itemName,
            PurchaseOrderId = p.PurchaseOrderId,
            PurchasePrice = p.PurchasePrice,
            Qty = p.Qty,
            Total = p.Total,
            TotalSys = p.TotalSys,
            UomId = p.UomId,
            UomName = uomName
        };
}