using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.API.Infra.Tables.Warehouses;

[Table("warehouses")]
public class WarehouseTable : BaseTable
{
    [Column("branch_id")]
    public int BranchId { get; set; }

    [Column("code")]
    public string Code { get; set; } = string.Empty;

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("stock_in", TypeName = "decimal(18,4)")]
    public decimal StockIn { get; set; }

    [Column("location")]
    public string? Location { get; set; }

    [Column("address")]
    public string? Address { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }
}