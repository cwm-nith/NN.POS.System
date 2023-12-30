using FluentValidation;
using NN.POS.Model.Dtos.Company.Branches;

namespace NN.POS.Web.Validations.Branches;

public class CreateUpdateBranchValidation : BaseValidator<CreateBranchDto>
{
    public CreateUpdateBranchValidation()
    {
        RuleFor(i => i.Address)
            .NotEmpty()
            .WithMessage("Please input address");

        RuleFor(i => i.Location)
            .NotEmpty()
            .WithMessage("Please input location");

        RuleFor(i => i.Name)
            .NotEmpty()
            .WithMessage("Please input name");

        RuleFor(i => i.CompanyId)
            .NotEmpty()
            .WithMessage("Please choose company")
            .Must(i => i > 0)
            .WithMessage("Please choose company");
    }
}