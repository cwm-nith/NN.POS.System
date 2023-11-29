using FluentValidation;
using NN.POS.Model.Dtos.Users;

namespace NN.POS.Web.Validations.Auth;

public class LoginValidation : AbstractValidator<LoginDto>
{
    public LoginValidation()
    {
        RuleFor(_ => _.Username)
            .NotEmpty()
            .WithMessage("Username required");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password required");
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result =
            await ValidateAsync(ValidationContext<LoginDto>.CreateWithOptions((LoginDto)model, x => x.IncludeProperties(propertyName)));
        return result.IsValid ? Array.Empty<string>() : result.Errors.Select(e => e.ErrorMessage);
    };
}