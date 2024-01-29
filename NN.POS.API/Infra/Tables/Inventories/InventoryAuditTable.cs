using NN.POS.Model.Dtos.Inventories;
using NN.POS.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.API.Infra.Tables.Inventories;

[Table("inventory_audit")]
public class InventoryAuditTable : BaseTable
{
    [Column("warehouse_id")]
    public int WarehouseId { get; set; }

    [Column("branch_id")]
    public int BranchId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("ccy_id")]
    public int CcyId { get; set; }

    [Column("uom_id")]
    public int UomId { get; set; }

    [Column("invoice_no"), StringLength(20)]
    public string InvoiceNo { get; set; } = string.Empty;

    [Column("trans_type")]
    public DocumentInvoicingType TransType { get; set; }

    [Column("process")]
    public ItemMasterDataProcess Process { get; set; }

    [Column("qty", TypeName = "decimal(18,4)")]
    public decimal Qty { get; set; }

    [Column("cost", TypeName = "decimal(18,4)")]
    public decimal Cost { get; set; }

    [Column("price", TypeName = "decimal(18,4)")]
    public decimal Price { get; set; }

    [Column("cumulative_qty", TypeName = "decimal(18,4)")]
    public decimal CumulativeQty { get; set; }

    [Column("cumulative_value", TypeName = "decimal(18,4)")]
    public decimal CumulativeValue { get; set; }

    [Column("trans_value", TypeName = "decimal(18,4)")]
    public decimal TransValue { get; set; }

    [Column("expire_date")]
    public DateTime? ExpireDate { get; set; }

    [Column("local_ccy_id")]
    public int LocalCcyId { get; set; }

    [Column("local_set_rate", TypeName = "decimal(18,4)")]
    public decimal LocalSetRate { get; set; }
}

public static class InventoryAuditExtensions
{
    public static InventoryAuditDto ToDto(this InventoryAuditTable i) => new()
    {
        BranchId = i.BranchId,
        CcyId = i.CcyId,
        Cost = i.Cost,
        CreatedAt = i.CreatedAt,
        CumulativeQty = i.CumulativeQty,
        CumulativeValue = i.CumulativeValue,
        ExpireDate = i.ExpireDate,
        Id = i.Id,
        InvoiceNo = i.InvoiceNo,
        ItemId = i.ItemId,
        LocalCcyId = i.LocalCcyId,
        LocalSetRate = i.LocalSetRate,
        Price = i.Price,
        Process = i.Process,
        Qty = i.Qty,
        TransType = i.TransType,
        TransValue = i.TransValue,
        UomId = i.UomId,
        UserId = i.UserId,
        WarehouseId = i.WarehouseId
    };

    public static InventoryAuditTable ToTable(this InventoryAuditDto i) => new()
    {
        BranchId = i.BranchId,
        CcyId = i.CcyId,
        Cost = i.Cost,
        CreatedAt = i.CreatedAt,
        CumulativeQty = i.CumulativeQty,
        CumulativeValue = i.CumulativeValue,
        ExpireDate = i.ExpireDate,
        Id = i.Id,
        InvoiceNo = i.InvoiceNo,
        ItemId = i.ItemId,
        LocalCcyId = i.LocalCcyId,
        LocalSetRate = i.LocalSetRate,
        Price = i.Price,
        Process = i.Process,
        Qty = i.Qty,
        TransType = i.TransType,
        TransValue = i.TransValue,
        UomId = i.UomId,
        UserId = i.UserId,
        WarehouseId = i.WarehouseId
    };
}