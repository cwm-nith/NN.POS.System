namespace NN.POS.Model.Dtos.Currencies;

public class CreateExchangeRateDto : IBaseDto
{
    public int CcyId { get; set; }
    public decimal Rate { get; set; }
    public decimal SetRate { get; set; }
}