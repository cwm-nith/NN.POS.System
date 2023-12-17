using FluentValidation;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.Web.Validations.Uoms.UomGroups;

public class CreateUomGroupValidation : BaseValidator<CreateUomGroupDto>
{
    public CreateUomGroupValidation()
    {
        RuleFor(i => i.Name)
            .NotEmpty()
            .WithMessage("Name is require");
    }
}