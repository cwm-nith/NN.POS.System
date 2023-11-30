using FluentValidation;
using NN.POS.Model.Dtos.Users;

namespace NN.POS.Web.Validations.Users;

public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
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

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result =
            await ValidateAsync(ValidationContext<UpdateUserDto>.CreateWithOptions((UpdateUserDto)model, x => x.IncludeProperties(propertyName)));
        return result.IsValid ? Array.Empty<string>() : result.Errors.Select(e => e.ErrorMessage);
    };
}