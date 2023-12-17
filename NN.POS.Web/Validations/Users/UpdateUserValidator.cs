using FluentValidation;
using NN.POS.Model.Dtos.Users;

namespace NN.POS.Web.Validations.Users;

public class UpdateUserValidator : BaseValidator<UpdateUserDto>
{
    public UpdateUserValidator()
    {
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
    }
}