using NN.POS.Model.Enums;

namespace NN.POS.Model.Dtos.Tax;

public class TaxDto : IBaseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Rate { get; set; }
    public TaxType Type { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
}