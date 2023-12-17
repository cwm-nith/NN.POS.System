using FluentValidation;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.Web.Validations.Uoms;

public class CreateUomValidation : BaseValidator<CreateUomDto>
{
    public CreateUomValidation()
    {
        RuleFor(i => i.Name)
            .NotEmpty()
            .WithMessage("Name is require");
    }
}