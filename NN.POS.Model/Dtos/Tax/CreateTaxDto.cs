using NN.POS.Model.Enums;

namespace NN.POS.Model.Dtos.Tax;

public class CreateTaxDto : IBaseDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Rate { get; set; }
    public TaxType Type { get; set; }
    public DateTime? EffectiveDate { get; set; }
}