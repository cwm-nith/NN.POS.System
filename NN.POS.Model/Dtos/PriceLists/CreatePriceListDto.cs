namespace NN.POS.Model.Dtos.PriceLists;

public class CreatePriceListDto : IBaseDto
{
    public string Name { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public int CcyId { get; set; }
}