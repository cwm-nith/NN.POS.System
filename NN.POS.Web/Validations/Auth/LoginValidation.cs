using FluentValidation;
using NN.POS.Model.Dtos.Users;

namespace NN.POS.Web.Validations.Auth;

public class LoginValidation : BaseValidator<LoginDto>
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
}