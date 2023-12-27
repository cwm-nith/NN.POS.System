namespace NN.POS.Model.Dtos.Warehouses;

public class UpdateWarehouseDto : IBaseDto
{
    public int BranchId { get; set; }
    public string? Name { get; set; }
    public decimal StockIn { get; set; }
    public string? Location { get; set; }
    public string? Address { get; set; }
}