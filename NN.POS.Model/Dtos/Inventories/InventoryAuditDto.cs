using NN.POS.Model.Enums;

namespace NN.POS.Model.Dtos.Inventories;
public class InventoryAuditDto : IBaseDto
{
    public int Id { get; set; }
    public int WarehouseId { get; set; }
    public int BranchId { get; set; }
    public int UserId { get; set; }
    public int ItemId { get; set; }
    public int CcyId { get; set; }
    public int UomId { get; set; }
    public string InvoiceNo { get; set; } = string.Empty;
    public DocumentInvoicingType TransType { get; set; }
    public ItemMasterDataProcess Process { get; set; }
    public decimal Qty { get; set; }
    public decimal Cost { get; set; }
    public decimal Price { get; set; }
    public decimal CumulativeQty { get; set; }
    public decimal CumulativeValue { get; set; }
    public decimal TransValue { get; set; }
    public DateTime? ExpireDate { get; set; }
    public int LocalCcyId { get; set; }
    public decimal LocalSetRate { get; set; }
    public DateTime CreatedAt { get; set; }
}
