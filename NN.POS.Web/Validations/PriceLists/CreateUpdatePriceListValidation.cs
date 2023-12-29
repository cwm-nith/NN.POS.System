using FluentValidation;
using NN.POS.Model.Dtos.PriceLists;

namespace NN.POS.Web.Validations.PriceLists;

public class CreateUpdatePriceListValidation : BaseValidator<CreatePriceListDto>
{
    public CreateUpdatePriceListValidation()
    {
        RuleFor(i => i.CcyId)
            .NotEmpty()
            .WithMessage("Please choose Currency")
            .Must(i => i > 0)
            .WithMessage("Please choose Currency");

        RuleFor(i => i.Name)
            .NotEmpty()
            .WithMessage("Please input name");
    }
}