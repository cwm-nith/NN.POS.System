using FluentValidation;
using NN.POS.Model.Dtos.Roles;

namespace NN.POS.Web.Validations.Roles;

public class CreateRoleValidator : BaseValidator<CreateRoleDto>
{
    public CreateRoleValidator()
    {
        RuleFor(i => i.Name)
            .NotEmpty()
            .WithMessage("Role name cannot be null!");
    }
}