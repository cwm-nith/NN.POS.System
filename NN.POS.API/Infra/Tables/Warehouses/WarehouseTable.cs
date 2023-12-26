using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NN.POS.Model.Dtos.Warehouses;

namespace NN.POS.API.Infra.Tables.Warehouses;

[Table("warehouses")]
public class WarehouseTable : BaseTable
{
    [Column("branch_id")]
    public int BranchId { get; set; }

    [Column("code"), StringLength(20)]
    public string Code { get; set; } = string.Empty;

    [Column("name"), StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [Column("stock_in", TypeName = "decimal(18,4)")]
    public decimal StockIn { get; set; }

    [Column("location"), StringLength(200)]
    public string? Location { get; set; }

    [Column("address"), StringLength(200)]
    public string? Address { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }
}

public static class WarehouseExtensions
{
    public static WarehouseDto ToDto(this WarehouseTable w, string? branchName = null) => new()
    {
        Name = w.Name,
        Address = w.Address,
        BranchId = w.BranchId,
        BranchName = branchName,
        Code = w.Code,
        CreatedAt = w.CreatedAt,
        Id = w.Id,
        IsDeleted = w.IsDeleted,
        Location = w.Location,
        StockIn = w.StockIn
    };

    public static WarehouseTable ToTable(this WarehouseDto w) => new()
    {
        Name = w.Name,
        Address = w.Address,
        BranchId = w.BranchId,
        Code = w.Code,
        CreatedAt = w.CreatedAt,
        Id = w.Id,
        IsDeleted = w.IsDeleted,
        Location = w.Location,
        StockIn = w.StockIn
    };
}