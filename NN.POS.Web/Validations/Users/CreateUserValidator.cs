using FluentValidation;
using NN.POS.Model.Dtos.Users;

namespace NN.POS.Web.Validations.Users;

public class CreateUserValidator : BaseValidator<CreateUserBfDto>
{
    public CreateUserValidator()
    {
        RuleFor(i => i.Username)
            .NotEmpty()
            .WithMessage("Username is require")
            .MaximumLength(50)
            .WithMessage("Username must be less than 50 characters")
            .Matches("^[^£# “”\"!@$%^&*(){}:;<>,.?/+=|'~\\-]*$")
            .WithMessage("Username must not contain the any special characters or spaces except _.");

        RuleFor(i => i.Name)
            .NotEmpty()
            .WithMessage("Name is require")
            .MaximumLength(50)
            .WithMessage("Name must be less than 50 characters");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Email is not a valid email address");

        RuleFor(p => p.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .MinimumLength(5)
            .WithMessage("Password must at least 5 characters")
            .Matches("[A-Z]").WithMessage("Password must contain one or more capital letters.")
            .Matches("[a-z]").WithMessage("Password must contain one or more lowercase letters.")
            .Matches(@"\d").WithMessage("Password must contain one or more digits.")
            .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("Password must contain at least one special character.");

        RuleFor(p => p.ConfirmPassword)
            .Equal(p => p.Password)
            .WithMessage("Confirm password doesn't match the password");
    }
}