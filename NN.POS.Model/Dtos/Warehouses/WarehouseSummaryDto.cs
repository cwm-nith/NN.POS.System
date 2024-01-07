namespace NN.POS.Model.Dtos.Warehouses;

public class WarehouseSummaryDto : IBaseDto
{
    public int Id { get; set; }
    public int WarehouseId { get; set; }
    public int UomId { get; set; }
    public int UserId { get; set; }
    public decimal InStock { get; set; }
    public decimal CommittedStock { get; set; }
    public decimal OrderedStock { get; set; }
    public decimal AvailableStock { get; set; }
    public decimal Factor { get; set; }
    public int CcyId { get; set; }
    public DateTime? ExpireDate { get; set; }
    public int ItemId { get; set; }
    public decimal Cost { get; set; }
    public DateTime CreatedAt { get; set; }
}