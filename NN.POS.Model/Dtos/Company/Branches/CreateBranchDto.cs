namespace NN.POS.Model.Dtos.Company.Branches;

public class CreateBranchDto : IBaseDto
{
    public string Name { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public string? CompanyName { get; set; }
    public string Location { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}