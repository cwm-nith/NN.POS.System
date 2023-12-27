namespace NN.POS.Model.Dtos.Company;

public class CompanyDto : IBaseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int PriceListId { get; set; }
    public string? PriceListName { get; set; }
    public int SysCcyId { get; set; }
    public string? SysCcyName { get; set; }
    public int LocalCcyId { get; set; }
    public string? LocalCcyName { get; set; }
    public string? Location { get; set; }
    public string? Address { get; set; }
    public bool IsDeleted { get; set; }
    public string? Logo { get; set; }
    public DateTime CreatedAt { get; set; }
}