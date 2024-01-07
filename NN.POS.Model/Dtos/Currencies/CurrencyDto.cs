namespace NN.POS.Model.Dtos.Currencies;

public class CurrencyDto : IBaseDto
{
    public int Id { get; set; }
    public string Symbol { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public ExchangeRateDto? ExchangeRate { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
}