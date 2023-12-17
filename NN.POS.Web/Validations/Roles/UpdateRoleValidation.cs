using FluentValidation;
using NN.POS.Model.Dtos.Roles;

namespace NN.POS.Web.Validations.Roles;

public class UpdateRoleValidator : BaseValidator<UpdateRoleDto>
{
    public UpdateRoleValidator()
    {
        RuleFor(i => i.Name)
            .NotEmpty()
            .WithMessage("Role name cannot be null!");
    }
}