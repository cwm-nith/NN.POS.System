namespace NN.POS.Model.Dtos.PaymentTypes;

public class PaymentTypeDto : IBaseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
}