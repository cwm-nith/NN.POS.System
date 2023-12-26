using FluentValidation;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.Web.Validations.Currencies;

public class CreateUpdateValidation : BaseValidator<CreateCurrencyDto>
{
    public CreateUpdateValidation()
    {
        RuleFor(i => i.Name)
            .NotEmpty()
            .WithMessage("Please input name.");

        RuleFor(i => i.Symbol)
            .NotEmpty()
            .WithMessage("Please input symbol.");
    }
}