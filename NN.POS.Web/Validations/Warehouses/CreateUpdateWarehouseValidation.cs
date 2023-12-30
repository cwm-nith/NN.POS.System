using FluentValidation;
using NN.POS.Model.Dtos.Warehouses;

namespace NN.POS.Web.Validations.Warehouses;

public class CreateUpdateWarehouseValidation : BaseValidator<CreateWarehouseDto>
{
    public CreateUpdateWarehouseValidation()
    {
        RuleFor(i => i.Name)
            .NotEmpty()
            .WithMessage("Please input name");

        RuleFor(i => i.Code)
            .NotEmpty()
            .WithMessage("Please input code");

        RuleFor(i => i.Location)
            .NotEmpty()
            .WithMessage("Please input location");

        RuleFor(i => i.Address)
            .NotEmpty()
            .WithMessage("Please input address");

        RuleFor(i => i.BranchId)
            .NotEmpty()
            .WithMessage("Please choose branch")
            .Must(i => i > 0)
            .WithMessage("Please choose branch");
    }
}