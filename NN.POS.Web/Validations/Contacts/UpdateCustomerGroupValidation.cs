using FluentValidation;
using NN.POS.Model.Dtos.BusinessPartners.CustomerGroups;

namespace NN.POS.Web.Validations.Contacts;

public class UpdateCustomerGroupValidation : BaseValidator<UpdateCustomerGroupDto>
{
    public UpdateCustomerGroupValidation()
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
}