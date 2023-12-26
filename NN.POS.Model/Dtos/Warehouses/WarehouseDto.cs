namespace NN.POS.Model.Dtos.Warehouses;

public class WarehouseDto : IBaseDto
{
    public int Id { get; set; }
    public int BranchId { get; set; }
    public string? BranchName { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal StockIn { get; set; }
    public string? Location { get; set; }
    public string? Address { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
}