namespace NN.POS.Model.Dtos.Currencies;

public class CreateCurrencyDto : IBaseDto
{
    public string Symbol { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}