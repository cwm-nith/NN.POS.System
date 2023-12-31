using FluentValidation;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.Web.Validations.Currencies;

public class CreateUpdateExchangeRateValidation : BaseValidator<CreateExchangeRateDto>
{
    public CreateUpdateExchangeRateValidation()
    {
        RuleFor(i => i.Rate)
            .NotEmpty()
            .WithMessage("Please input Rate")
            .GreaterThan(0)
            .WithMessage("Rate must be greater than zero");

        RuleFor(i => i.SetRate)
            .NotEmpty()
            .WithMessage("Please input Set Rate")
            .GreaterThan(0)
            .WithMessage("Set Rate must be greater than zero");

        RuleFor(i => i.CcyId)
            .NotEmpty()
            .WithMessage("Please choose Currency")
            .GreaterThan(0)
            .WithMessage("Please choose Currency");
    }
}