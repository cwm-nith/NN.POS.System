using System.ComponentModel.DataAnnotations.Schema;
using NN.POS.Model.Dtos.Warehouses;

namespace NN.POS.API.Infra.Tables.Warehouses;

[Table("warehouse_summaries")]
public class WarehouseSummaryTable : BaseTable
{
    [Column("warehouse_id")]
    public int WarehouseId { get; set; }
    [Column("uom_id")]
    public int UomId { get; set; }
    [Column("user_id")]
    public int UserId { get; set; }
    [Column("in_stock", TypeName = "decimal(18.3)")]
    public decimal InStock { get; set; }
    [Column("committed_stock", TypeName = "decimal(18.3)")]
    public decimal CommittedStock { get; set; }
    [Column("ordered_stock", TypeName = "decimal(18.3)")]
    public decimal OrderedStock { get; set; }
    [Column("available_stock", TypeName = "decimal(18.3)")]
    public decimal AvailableStock { get; set; }
    [Column("factor", TypeName = "decimal(18.3)")]
    public decimal Factor { get; set; }
    [Column("ccy_id")]
    public int CcyId { get; set; }
    [Column("expire_date")]
    public DateTime? ExpireDate { get; set; }
    [Column("item_id")]
    public int ItemId { get; set; }
    [Column("cost", TypeName = "decimal(18.3)")]
    public decimal Cost { get; set; }
}

public static class WarehouseSummaryExtensions
{
    public static WarehouseSummaryDto ToDto(this WarehouseSummaryTable w) => new()
    {
        CreatedAt = w.CreatedAt,
        AvailableStock = w.AvailableStock,
        CcyId = w.CcyId,
        CommittedStock = w.CommittedStock,
        Cost = w.Cost,
        ExpireDate = w.ExpireDate,
        Factor = w.Factor,
        Id = w.Id,
        UserId = w.UserId,
        InStock = w.InStock,
        ItemId = w.ItemId,
        OrderedStock = w.OrderedStock,
        UomId = w.UomId,
        WarehouseId = w.WarehouseId
    };

    public static WarehouseSummaryTable ToTable(this WarehouseSummaryDto w) => new()
    {
        CreatedAt = w.CreatedAt,
        AvailableStock = w.AvailableStock,
        CcyId = w.CcyId,
        CommittedStock = w.CommittedStock,
        Cost = w.Cost,
        ExpireDate = w.ExpireDate,
        Factor = w.Factor,
        Id = w.Id,
        UserId = w.UserId,
        InStock = w.InStock,
        ItemId = w.ItemId,
        OrderedStock = w.OrderedStock,
        UomId = w.UomId,
        WarehouseId = w.WarehouseId
    };
}