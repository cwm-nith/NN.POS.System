using FluentValidation;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.Web.Validations.Uoms;

public class UpdateUomValidation : BaseValidator<UpdateUomDto>
{
    public UpdateUomValidation()
    {
        RuleFor(i => i.Name)
            .NotEmpty()
            .WithMessage("Name is require");
    }
}