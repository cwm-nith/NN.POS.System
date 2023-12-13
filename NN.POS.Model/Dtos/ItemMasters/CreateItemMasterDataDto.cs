using NN.POS.Model.Enums;

namespace NN.POS.Model.Dtos.ItemMasters;

public class CreateItemMasterDataDto : IBaseDto
{
    public string Code { get; set; } = string.Empty;
    public string Barcode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? OtherName { get; set; }
    public decimal StockIn { get; set; }
    public decimal StockCommit { get; set; }
    public decimal StockOnHand { get; set; }
    public int BaseUomId { get; set; }
    public int PriceListId { get; set; }
    public int UomGroupId { get; set; }
    public int? PurchaseUomId { get; set; }
    public int? SaleUomId { get; set; }
    public int? InventoryUoMid { get; set; }
    public int WarehouseId { get; set; }

    /// <summary>
    /// None = 0,
    /// Group = 1,
    /// Item = 2,
    /// Service = 3, 
    /// Labor = 4
    /// </summary>
    public ItemMasterDataType Type { get; set; }
    public bool IsInventory { get; set; }
    public bool IsSale { get; set; }
    public bool IsPurchase { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }

    /// <summary>
    /// None = 0,
    /// Fifo = 1,
    /// Average = 2,
    /// Standard = 3
    /// </summary>
    public ItemMasterDataProcess Process { get; set; }
}