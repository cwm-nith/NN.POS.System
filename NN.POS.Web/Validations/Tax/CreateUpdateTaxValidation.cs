using FluentValidation;
using NN.POS.Model.Dtos.Tax;
using NN.POS.Model.Enums;

namespace NN.POS.Web.Validations.Tax;

public class CreateUpdateTaxValidation : BaseValidator<CreateTaxDto>
{
    public CreateUpdateTaxValidation()
    {
        RuleFor(i => i.EffectiveDate)
            .NotEmpty()
            .WithMessage("Please select Effective Date")
            .GreaterThanOrEqualTo(DateTime.Today)
            .WithMessage("Effective Date must be greater than current date");

        RuleFor(i => i.Name)
            .NotEmpty()
            .WithMessage("Please input name");

        RuleFor(i => i.Rate)
            .NotEmpty()
            .WithMessage("Please input rate")
            .Must(i => i > 0)
            .WithMessage("Rate must be greater than zero");

        RuleFor(i => i.Type)
            .Must(i => i != TaxType.None)
            .WithMessage("Please select Rate Type");
    }
}