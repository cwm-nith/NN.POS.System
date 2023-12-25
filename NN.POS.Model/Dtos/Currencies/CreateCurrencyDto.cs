namespace NN.POS.Model.Dtos.Currencies;

public class CreateCurrencyDto : IBaseDto
{
    public string? Symbol { get; set; }
    public string? Name { get; set; }
}