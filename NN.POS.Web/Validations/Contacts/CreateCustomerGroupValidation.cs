using FluentValidation;
using NN.POS.Model.Dtos.BusinessPartners.CustomerGroups;

namespace NN.POS.Web.Validations.Contacts;

public class CreateCustomerGroupValidation : AbstractValidator<CreateCustomerGroupDto>
{

    public CreateCustomerGroupValidation()
    {
        RuleFor(i => i.Name)
            .NotEmpty()
            .WithMessage("Name is require");

        RuleFor(x => x.Value)
            .NotEmpty()
            .WithMessage("Value is required")
            .Must(i => i > 0)
            .WithMessage("Value must be greater than 0.");
    }
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result =
            await ValidateAsync(ValidationContext<CreateCustomerGroupDto>.CreateWithOptions((CreateCustomerGroupDto)model, x => x.IncludeProperties(propertyName)));
        return result.IsValid ? Array.Empty<string>() : result.Errors.Select(e => e.ErrorMessage);
    };
}