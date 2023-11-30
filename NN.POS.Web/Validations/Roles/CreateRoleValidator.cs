using FluentValidation;
using NN.POS.Model.Dtos.Roles;

namespace NN.POS.Web.Validations.Roles;

public class CreateRoleValidator : AbstractValidator<CreateRoleDto>
{
    public CreateRoleValidator()
    {
        RuleFor(i => i.Name)
            .NotEmpty()
            .WithMessage("Role name cannot be null!");
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result =
            await ValidateAsync(ValidationContext<CreateRoleDto>.CreateWithOptions((CreateRoleDto)model, x => x.IncludeProperties(propertyName)));
        return result.IsValid ? Array.Empty<string>() : result.Errors.Select(e => e.ErrorMessage);
    };
}