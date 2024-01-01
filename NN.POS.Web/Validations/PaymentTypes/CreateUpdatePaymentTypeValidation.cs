using FluentValidation;
using NN.POS.Model.Dtos.PaymentTypes;

namespace NN.POS.Web.Validations.PaymentTypes;

public class CreateUpdatePaymentTypeValidation : BaseValidator<CreatePaymentTypeDto>
{
    public CreateUpdatePaymentTypeValidation()
    {
        RuleFor(i => i.Name)
            .NotEmpty()
            .WithMessage("Please input name")
            .MaximumLength(50)
            .WithMessage("Name must be less than 50 characters");
    }
}