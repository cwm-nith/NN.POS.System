using System.ComponentModel.DataAnnotations;
using NN.POS.Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using NN.POS.Model.Dtos.ItemMasters;

namespace NN.POS.API.Infra.Tables.ItemMasters;

[Table("item_master_data")]
public class ItemMasterDataTable : BaseTable
{
    [Column("group_id")] 
    public int? GroupId { get; set; }

    [Column("code"), StringLength(100)]
    public string Code { get; set; } = string.Empty;

    [Column("barcode"), StringLength(100)]
    public string Barcode { get; set; } = string.Empty;

    [Column("name"), StringLength(250)]
    public string Name { get; set; } = string.Empty;

    [Column("other_name"), StringLength(250)]
    public string? OtherName { get; set; }

    [Column("stock_in", TypeName = "decimal(18,2)")]
    public decimal StockIn { get; set; }

    [Column("stock_commit", TypeName = "decimal(18,2)")]
    public decimal StockCommit { get; set; }

    [Column("stock_on_hand", TypeName = "decimal(18,2)")]
    public decimal StockOnHand { get; set; }

    [Column("base_uom_id")]
    public int BaseUomId { get; set; }

    [Column("price_list_id")]
    public int PriceListId { get; set; }

    [Column("uom_group_id")]
    public int UomGroupId { get; set; }

    [Column("purchase_uom_id")]
    public int? PurchaseUomId { get; set; }

    [Column("sale_uom_id")]
    public int? SaleUomId { get; set; }

    [Column("inventory_uom_id")]
    public int? InventoryUoMid { get; set; }

    [Column("warehouse_id")]
    public int WarehouseId { get; set; }

    /// <summary>
    /// None = 0,
    /// Group = 1,
    /// Item = 2,
    /// Service = 3, 
    /// Labor = 4
    /// </summary>
    [Column("type")]
    public ItemMasterDataType Type { get; set; }

    [Column("is_inventory")]
    public bool IsInventory { get; set; }

    [Column("is_sale")]
    public bool IsSale { get; set; }

    [Column("is_purchase")]
    public bool IsPurchase { get; set; }
    
    [Column("image"), StringLength(250)]
    public string? Image { get; set; }

    [Column("description"), StringLength(1000)]
    public string? Description { get; set; }

    /// <summary>
    /// None = 0,
    /// Fifo = 1,
    /// Average = 2,
    /// Standard = 3
    /// </summary>
    [Column("process")]
    public ItemMasterDataProcess Process { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [NotMapped]
    public IFormFile? File { get; set; }
}

public static class ItemMasterDataTableExtensions
{
    public static ItemMasterDataDto ToDto(this ItemMasterDataTable i, string? baseImageUrl = null) => new()
    {
        Barcode = i.Barcode,
        BaseUomId = i.BaseUomId,
        Code = i.Code,
        CreatedAt = i.CreatedAt,
        Description = i.Description,
        Id = i.Id,
        GroupId = i.GroupId,
        Image = $"{baseImageUrl}{i.Image}",
        InventoryUoMid = i.InventoryUoMid,
        IsDeleted = i.IsDeleted,
        IsSale = i.IsSale,
        IsPurchase = i.IsPurchase,
        IsInventory = i.IsInventory,
        Name = i.Name,
        PriceListId = i.PriceListId,
        OtherName = i.OtherName,
        Process = i.Process,
        PurchaseUomId = i.PurchaseUomId,
        SaleUomId = i.SaleUomId,
        StockCommit = i.StockCommit,
        StockIn = i.StockIn,
        StockOnHand = i.StockOnHand,
        Type = i.Type,
        UomGroupId = i.UomGroupId,
        WarehouseId = i.WarehouseId
    };

    public static ItemMasterDataTable ToTable(this ItemMasterDataDto i) => new()
    {
        Barcode = i.Barcode,
        BaseUomId = i.BaseUomId,
        Code = i.Code,
        CreatedAt = i.CreatedAt,
        Description = i.Description,
        Id = i.Id,
        GroupId = i.GroupId,
        Image = i.Image?.Split('/')[^1],
        InventoryUoMid = i.InventoryUoMid,
        IsDeleted = i.IsDeleted,
        IsSale = i.IsSale,
        IsPurchase = i.IsPurchase,
        IsInventory = i.IsInventory,
        Name = i.Name,
        PriceListId = i.PriceListId,
        OtherName = i.OtherName,
        Process = i.Process,
        PurchaseUomId = i.PurchaseUomId,
        SaleUomId = i.SaleUomId,
        StockCommit = i.StockCommit,
        StockIn = i.StockIn,
        StockOnHand = i.StockOnHand,
        Type = i.Type,
        UomGroupId = i.UomGroupId,
        WarehouseId = i.WarehouseId
    };
}