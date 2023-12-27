namespace NN.POS.Model.Dtos.Warehouses;

public class CreateWarehouseDto : IBaseDto
{
    public int BranchId { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public decimal StockIn { get; set; }
    public string? Location { get; set; }
    public string? Address { get; set; }
}