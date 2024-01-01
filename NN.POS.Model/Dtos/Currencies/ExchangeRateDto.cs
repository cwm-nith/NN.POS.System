namespace NN.POS.Model.Dtos.Currencies;

public class ExchangeRateDto : IBaseDto
{
    public int Id { get; set; }
    public int CcyId { get; set; }
    public string? CcyName { get; set; }
    public decimal Rate { get; set; }
    public bool IsDeleted { get; set; }
    public decimal SetRate { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? BaseCcy { get; set; }
}