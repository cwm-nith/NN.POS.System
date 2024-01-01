namespace NN.POS.Model.Dtos.PaymentTypes;

public class CreatePaymentTypeDto : IBaseDto
{
    public string Name { get; set; } = string.Empty;
}