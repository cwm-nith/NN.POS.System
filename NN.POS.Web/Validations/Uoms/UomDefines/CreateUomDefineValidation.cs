using FluentValidation;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.Web.Validations.Uoms.UomDefines;

public class CreateUomDefineValidation : BaseValidator<CreateUomDefineDto>
{
    public CreateUomDefineValidation()
    {
        RuleFor(i => i.AltQty)
            .Must(i => i > 0)
            .WithMessage("Alt Qty must be greater than 0");
        RuleFor(i => i.BaseQty)
            .Must(i => i > 0)
            .WithMessage("Base Qty must be greater than 0");
        RuleFor(i => i.Factor)
            .Must(i => i > 0)
            .WithMessage("Factor must be greater than 0");
        RuleFor(i => i.AltUomId)
            .Must(i => i > 0)
            .WithMessage("Please choose alt uom.");
        RuleFor(i => i.BaseUomId)
            .Must(i => i > 0)
            .WithMessage("Please choose base uom.");
    }
}