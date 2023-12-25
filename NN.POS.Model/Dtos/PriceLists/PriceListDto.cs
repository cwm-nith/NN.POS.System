namespace NN.POS.Model.Dtos.PriceLists;

public class PriceListDto : IBaseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public int CcyId { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<PriceListDetailDto> PriceListDetails { get; set; } = [];
}