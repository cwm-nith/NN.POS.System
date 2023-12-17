using FluentValidation;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.Web.Validations.Uoms.UomGroups;

public class UpdateUomGroupValidation : BaseValidator<UpdateUomGroupDto>
{
    public UpdateUomGroupValidation()
    {
        RuleFor(i => i.Name)
            .NotEmpty()
            .WithMessage("Name is require");
    }
}